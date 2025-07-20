
using bankwebApi.Models;
using bankwebApi.repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace bankwebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private faq_repo faq;
        private db_context _con;
         
        public AdminController(faq_repo faq_data,db_context con )
        {
            faq = faq_data; 
            _con = con;
            
        }
        [HttpPost]
        public  async Task<ActionResult>add_faq(faq faqs)
        {
            await faq.insert_faq(faqs);
            return Ok(faqs);
        }
        [HttpGet]
        public async Task<ActionResult> faq_details()
        {
            var user_details = await faq.faq_fetch();
            return Ok(user_details);

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> faq_delete(int id)
        {
              await faq.delete_faq(id);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> updates_faq(int id ,faq faqs) {
        
            await faq.Update_faq(id, faqs); 
            return Ok();


        }
        [HttpGet("solo_account/{id}")]
        public async Task<ActionResult<user_account>> account_details(int id) {

           var details= await _con.tbl_accounts.Where(u=>u.id == id).ToListAsync();

            return Ok(details);
        }
        [HttpPost("admin_created")]
        public async Task<ActionResult> admin_created(user users)
        {
            users.is_admin = 1;
            users.status = 1;
            _con.tbl_users.Add(users);
           await _con.SaveChangesAsync();
            return Ok(users);


        }
        [HttpGet("admin_details/{is_admin}")]
    
        public async Task<ActionResult<user>> admin_details(int is_admin)
        {
            var details = await _con.tbl_users.Where(u => u.is_admin == is_admin).ToListAsync();

            return Ok(details);
        }
    }
}
