
using bankwebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace bankwebApi.repository
{
    public class faq_repo
    {
        private readonly db_context _con;
        public faq_repo(db_context con)
        {
            this._con = con;

        }
       /*for the insert the faq database*/
        public  async Task insert_faq(faq faqs)
        {
          await  _con.tbl_faqs.AddAsync(faqs);
           await _con.SaveChangesAsync();

        } 
        public async Task<List<faq>> faq_fetch()
        {
         return   await _con.tbl_faqs.ToListAsync();

        }
        public async Task delete_faq(int id)
        {
            var del = await _con.tbl_faqs.FindAsync(id);
            _con.tbl_faqs.Remove(del);
            await _con.SaveChangesAsync();
        }
        /*for update the record*/
        public async Task Update_faq(int id,faq faqs)
        {
            // Find the existing FAQ by ID
            var existingFaq = await _con.tbl_faqs.FindAsync(id);

            // Check if the FAQ exists
            if (existingFaq == null)
            {
                throw new Exception("FAQ not found");
            }

            // Update the properties of the existing FAQ
            existingFaq.subject = faqs.subject; // Assuming you have a Subject property
            existingFaq.question = faqs.question; // Assuming you have a Question property
            existingFaq.answer = faqs.answer; // Assuming you have an Answer property

            // Save changes to the database
            await _con.SaveChangesAsync();
        }


        public async Task add_loan(loans loan) {

            loan.status = 0;
           await _con.tbl_loans.AddAsync(loan);
            await _con.SaveChangesAsync();
        }
        public async Task user_Solo_loan(int user_id)
        {
          await  _con.tbl_loans.Where(p => p.user_id == user_id).ToListAsync();
        }
        public async Task user_solo_delete(int id)
        {
          var del=  await _con.tbl_loans.FindAsync(id);
             _con.tbl_loans.Remove(del);
            await _con.SaveChangesAsync();
        }
        public async Task _loandetails()
        {
            await _con.tbl_loans.ToListAsync();
        }
    }
}
