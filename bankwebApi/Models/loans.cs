using System.ComponentModel.DataAnnotations;

namespace bankwebApi.Models
{
    public class loans
    {
        [Key]
        public int id { get; set; }

        public string name { get; set; }
        public string email { get; set; }
        public string number { get; set; }
        public string Cnic { get; set; }
        public string emply_type { get; set; }
        public string emply { get; set; }
        public string orgazination_name { get; set; }
        public string address { get; set; }
        public string DOB { get; set; }
        public int loan_amount { get; set; }
        public int user_id { get; set; }
        public int status { get; set; }
        public int salary { get; set; }
        public string repayment_period { get; set; }
    }
}
