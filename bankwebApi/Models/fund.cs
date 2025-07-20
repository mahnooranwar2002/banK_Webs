using System.ComponentModel.DataAnnotations;

namespace bankwebApi.Models
{
    public class fund
    {
        [Key]
        public int Id { get; set; }
        

        public string name { get; set; }
        public int pin_code { get; set; }
        public string account_id { get; set; }
        public string receiverName { get; set; }
        public string receiverNo { get; set; }
        public int fund_amount { get; set; }
        public int user_id { get; set; }
        public string massage  { get; set; }
    }
}
