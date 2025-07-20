using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bankwebApi.Models
{
    public class user_account
    {
        [Key]
        public int id { get; set; }
    
        public string name { get; set; }
        public string gender { get; set; }
        public string email{ get; set; }
        public string phone { get; set; }

        public string address { get; set; }
        public string DOB { get; set; }
        public string pan_numbr { get; set; }
        public string nomine { get; set; }
        public string nomine_no { get; set; }
        
        public string account_id { get; set; }
        public int deposit_amount { get; set; }

        public int pin_code { get; set; }

        public int user_id { get; set; }
        public string types_id { get; set; }
  
        public int status { get; set; }



    }
}
