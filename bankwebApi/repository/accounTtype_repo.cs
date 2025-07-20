using bankwebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bankwebApi.repository
{
    public class accounTtype_repo
    {
        private db_context _con;
        public accounTtype_repo(db_context con)
        {
            _con = con;
        }

        public  async Task saveAcc_type(account_type type)
        {
           await _con.tbl_Acctypes.AddAsync(type);
            await _con.SaveChangesAsync();
        }
        public async Task<List<account_type>> Account_Typeslist()
        {
          return await _con.tbl_Acctypes.ToListAsync();
        }
       public async Task delete_faq(int id)
        {
            var del = await _con.tbl_Acctypes.FindAsync(id);
            _con.tbl_Acctypes.Remove(del);
            await _con.SaveChangesAsync();
        }
        public async Task update_typed(int id, account_type accType)
        {
            var info = await _con.tbl_Acctypes.FindAsync(id);
            if (info != null) {
                info.accountTYpe_id = accType.accountTYpe_id;
                info.accountTYpe_Name = accType.accountTYpe_Name;
                await _con.SaveChangesAsync();
            }
          
        }
        public async Task open_account(user_account acc)
        {
       
           await _con.tbl_accounts.AddAsync(acc);
           await _con.SaveChangesAsync();
        }


        public async Task fund_data(fund acc)
        {

            await _con.tbl_funds.AddAsync(acc);
            await _con.SaveChangesAsync();
        }
    }
}
