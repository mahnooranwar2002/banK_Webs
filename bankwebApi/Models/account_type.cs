using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bankwebApi.Models
{
    public class account_type
    {
        [Key]
       public int id { get; set; }
        public  string accountTYpe_id { get; set; }
        public string accountTYpe_Name { get; set; }
        
       
    

        

    }
}
