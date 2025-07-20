using bankwebApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;


namespace bankwebApi.repository
{
    public class user_repository
    {
        private db_context _con;
        public user_repository(db_context con)
        {
         this._con = con;
        }

       /*for the fetch the Record*/
       public async Task<List<user>> getuser_record()
        {
            return await _con.tbl_users.ToListAsync();
        }
      /*for the insert the user data*/
      //public async Task user_register(user user_data)
      //  {
      //      var existingemail = _con.tbl_users.FirstOrDefaultAsync(p => p.email == user_data.email);
      //      if (existingemail == null)
      //      {
      //          user_data.status = 1;
      //          user_data.is_admin = 0;
           
      //      }
      //      await _con.tbl_users.AddAsync(user_data);
      //      await _con.SaveChangesAsync();

      //  }
        public async Task user_register(user userData)
        {
            var existingEmail = await _con.tbl_users.FirstOrDefaultAsync(p => p.email == userData.email);

            if (existingEmail == null)
            {
                userData.status = 1;
                userData.is_admin = 0;

                await _con.tbl_users.AddAsync(userData);
                await _con.SaveChangesAsync();
            }
            else
            {
                // Handle the case where the email already exists
                // For example, you could throw an exception or return a specific result
                throw new Exception("Email already exists.");
            }
        }
        public async Task delete_user(int id)
        {
            var user = await _con.tbl_users.FindAsync(id);
            _con.tbl_users.Remove(user);
            await _con.SaveChangesAsync();
        }
        public async Task user_status(int id)
        {
            var user_data = await _con.tbl_users.FindAsync(id);
            if (user_data != null)
            {
                if (user_data.status == 1)
                {
                    user_data.status = 0;
                }
                else
                {
                    user_data.status = 1;
                }
            }
           await _con.SaveChangesAsync();
        }
        public async Task account_status(int id)
        {
            var user_data = await _con.tbl_accounts.FindAsync(id);
            if (user_data != null)
            {
                if (user_data.status == 1)
                {
                    user_data.status = 0;
                }
                else
                {
                    user_data.status = 1;
                }
            }
            await _con.SaveChangesAsync();
        }
        public async Task account_delete(int id)
        {
            var account_detail = await _con.tbl_accounts.FindAsync(id);
            _con.tbl_accounts.Remove(account_detail);
            await _con.SaveChangesAsync();

        }
        public async Task account_data(int id)
        {
            await _con.tbl_accounts.FindAsync(id);
            

        }
    }
}
