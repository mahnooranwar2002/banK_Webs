using Microsoft.EntityFrameworkCore;

namespace bankwebApi.Models
{
    public class db_context:DbContext
    {
        public db_context(DbContextOptions<db_context>options):base
        (options)
        {
            
        }
        public DbSet<user> tbl_users { get; set; }
        public DbSet<faq> tbl_faqs { get; set; }
        public DbSet<fund> tbl_funds { get; set; }
        public DbSet<loans> tbl_loans { get; set; }
        public DbSet<account_type> tbl_Acctypes { get; set; }
        public DbSet<user_account> tbl_accounts { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<user_account>().
        //        HasOne(h => h.accountdetails).
        //        WithMany(p => p.user_details).
        //        HasForeignKey(p => p.types_id);
        //}
    }
}
