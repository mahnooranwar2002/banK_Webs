using bankwebApi.Models;
using bankwebApi.repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bankwebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        private accounTtype_repo accounTtypes;
        public TypesController(accounTtype_repo accs)
        {
           this.accounTtypes = accs;
        }
        [HttpPost]
        public async Task<ActionResult> add_type(account_type typess)
        {
            Random random = new Random();
            var ids = random.Next(0000, 9999).ToString();

           typess.accountTYpe_id = "fIC-" + "" + ids;
            await accounTtypes.saveAcc_type(typess);
            return Ok(typess);
        }
        [HttpGet]
        public async Task<ActionResult> typelist()
        {
         var lists=  await accounTtypes.Account_Typeslist();
            return Ok(lists);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult>del_tpye(int id)
        {
            await accounTtypes.delete_faq(id);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> update_typed(int id, account_type type)
        {
            await accounTtypes.update_typed(id, type);
            return Ok();
        }
        
    }

}
