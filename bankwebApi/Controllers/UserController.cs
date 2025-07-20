
using System.Reflection.Metadata.Ecma335;
using bankwebApi.Models;
using bankwebApi.repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bankwebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private user_repository user_data;
        private accounTtype_repo accounTtype_Repo;
        private db_context _con;
        private faq_repo _loan;
        public UserController(user_repository user_repo, faq_repo loan,accounTtype_repo accounTtype_Repo,db_context con)
        {
            user_data = user_repo;
            _con = con;
            _loan = loan;
            this.accounTtype_Repo = accounTtype_Repo;
           
        }
        [HttpGet]
        public async Task<ActionResult> user_details() {
            var user_details = await user_data.getuser_record();
            return Ok(user_details);
        }
        [HttpPost]
        public async Task<ActionResult> add_user(user user_details)
        {
            //var existingemail = _con.tbl_users.FirstOrDefaultAsync(p => p.email == user_details.email);
            //if (existingemail != null)
            //{
            //    return Ok("the email is already registered");
            //}
           
            await user_data.user_register(user_details);
            return Ok(user_details);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> user_delete(int id)
        {
            await user_data.delete_user(id);
            return Ok();
        }
        [HttpPatch("status/{id}")]
        public async Task<ActionResult> user_status(int id)
        {
            await user_data.user_status(id);
            return Ok();
        }
        [HttpPost("acc_user")]
        public async Task<ActionResult> account_opened(user_account acc_details)
        {
            var useremail=await _con.tbl_accounts.FirstOrDefaultAsync(p => p.email == acc_details.email);
            if (useremail != null)
            {
                return Ok("the account is already registered");
            }

            Random random = new Random();
            var num = random.Next(00000, 99999).ToString();
            acc_details.account_id = num;
            acc_details.status = 0;

            await _con.tbl_accounts.AddAsync(acc_details);
            await _con.SaveChangesAsync();
            return Ok(acc_details);


        }
        [HttpPost("login")]
        public async Task<ActionResult<user>> user_Login([FromBody] user model)
        {
            // Find user by email
            var user = await _con.tbl_users.FirstOrDefaultAsync(u => u.email == model.email);

            // Check if user exists
            if (user == null || user.password != model.password)
            {
                return NotFound("Email or password is invalid");
            }

            // Check if the account is active
            if (user.status == 1)
            {
                return Ok(user); // Return success response
            }
            else
            {
                return NotFound("The account is deactivated by admin");
            }
        }
        [HttpGet("account_details")]
        public async Task<ActionResult<user_account>> account_get()
        {
          var details= await _con.tbl_accounts.ToListAsync();
            return Ok(details);
        }
        [HttpPatch("account_status/{id}")]
        public async Task<ActionResult> account_status(int id)
        {
            await user_data.account_status(id);
            return Ok();
        }
        [HttpDelete("account_del/{id}")]
        public async Task<ActionResult> account_delete(int id)
        {
            await user_data.account_delete(id);
            return Ok();
        }
        [HttpGet("account_data/{id}")]
        public async Task<ActionResult<user_account>> accounts_data(int id)
        {
            var user_data = await _con.tbl_accounts.Where(p => p.user_id == id).ToListAsync();
            return Ok(user_data);
        }
        [HttpGet("user_prof/{id}")]
        public async Task<ActionResult<user_account>> user_Profile(int id)
        {
            var user_profile = await _con.tbl_users.Where(p => p.Id == id).ToListAsync();
            return Ok(user_profile);
        }
        [HttpPut("profileUpdate/{id}")]
        public async Task<ActionResult<user>> user_update(int id ,user users)
        {
            var user_profile = await _con.tbl_users.FindAsync(id);
            if(user_profile == null)
            {
                return BadRequest("not record is found");
            }
            
            user_profile.Name = users.Name;
            user_profile.email = users.email;
            user_profile.password = users.password;
            user_profile.status= users.status;
          await  _con.SaveChangesAsync();
            return Ok(users);
        }


        //[HttpPost("fund_transfer")]
        //public async Task<ActionResult> trafer_funds(int pin_code,fund funds)
        //{
        //    var user = await _con.tbl_accounts.FirstOrDefaultAsync(u => u.pin_code == pin_code);
        //    if (user != null)
        //    {

        //        user.deposit_amount = user.deposit_amount - funds.fund_amount;
        //        await _con.tbl_funds.AddAsync(funds);
        //        await _con.SaveChangesAsync();
        //        return Ok(user);
        //    }
        //    else
        //    {
        //        return BadRequest("av");
        //    }

        //}
        //[HttpPost("fund_transfer")]
        //public async Task<ActionResult> TransferFunds(string account_id, int pin_code,int fund_amount, fund funds)
        //{


        //    // Fetch the user account based on the provided pin code
        //    var user = await _con.tbl_accounts.FirstOrDefaultAsync(u => u.pin_code == pin_code);

        //    // Check if the user exists and the account ID matches
        //    if (user != null && user.account_id == account_id)
        //    {
        //        // Check if there are sufficient funds
        //        if (funds.fund_amount <= user.deposit_amount)
        //        {
        //            user.deposit_amount = user.deposit_amount - funds.fund_amount; // Deduct the fund amount
        //            await _con.tbl_funds.AddAsync(funds); // Add the fund transaction
        //            await _con.SaveChangesAsync(); // Save changes to the database

        //            return Ok(user); // Return the updated user account
        //        }
        //        else
        //        {
        //            return BadRequest("Insufficient funds.");
        //        }
        //    }
        //    else
        //    {
        //        return BadRequest("Account not found or invalid credentials.");
        //    }
        //}
        //[HttpPost("fund_transfer/{pin_code}")]
        //public async Task<ActionResult> TransferFunds(int fund_amount, int pin_code, [FromBody] fund funds)
        //{
        //    var user = await _con.tbl_accounts.FirstOrDefaultAsync(u => u.pin_code == pin_code);
        //    if (user != null)
        //    {
        //       var dataa = user.deposit_amount - funds.fund_amount; // Deduct the fund amount
        //        await _con.tbl_funds.AddAsync(funds); // Add the fund record


        //        user.deposit_amount = user.deposit_amount;
        //        await _con.SaveChangesAsync();

        //        return Ok(user);

        //    }
        //    else
        //    {
        //        return BadRequest("User  not found with the provided pin code.");
        //    }
        //}
        //[HttpPost("fund_transfer")]
        //public async Task<ActionResult> TransferFunds(fund funds)
        //{

        //        await _con.tbl_funds.AddAsync(funds); 
        //        await _con.SaveChangesAsync();

        //        return Ok();

        //}




        [HttpPost("mydata")]
        public async Task<ActionResult> fundss(fund f) {
           await accounTtype_Repo.fund_data(f);
           
            return Ok(f);
        }

        [HttpPost("loan_inserted")]
        public async Task<ActionResult> loans_inserted(loans loan) {
            loan.status = 0;
            await _con.tbl_loans.AddAsync(loan);
            await _con.SaveChangesAsync();
            return Ok(loan);
        }
        [HttpGet("userLoans_details")]
        public async Task<ActionResult> loaan_data(int user_id)
        {
            var user_data = await _con.tbl_loans.Where(p => p.user_id == user_id).ToListAsync();
            if (user_data == null)
            {
                return BadRequest("as");
            }
          
            return Ok(user_data);
        }
        [HttpDelete("userLoans_delete/{id}")]
        public async Task<ActionResult> loans_del(int id)
        {
            var del = await _con.tbl_loans.FindAsync(id);
            if (del == null)
            {

                return Ok("Accc");
            }

            else
            {
                _con.tbl_loans.Remove(del);
                await _con.SaveChangesAsync();
                return Ok();

            }
        }
        [HttpGet("loans_details")]
        public async Task<ActionResult<loans>> loanDetails_get()
        {
         var data=   await _con.tbl_loans.ToListAsync();
            return Ok(data);
        }
        [HttpGet("loans_data/{id}")]
        public async Task<ActionResult<loans>> loanData_get(int id)
        {
            var data = await _con.tbl_loans.Where(p=>p.id==id).ToListAsync();
            return Ok(data);
        }
    }
}
