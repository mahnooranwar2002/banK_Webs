using System.ComponentModel.DataAnnotations;

namespace bankwebApi.Models
{
    public class faq
    {
        [Key]
        public int Id { get; set; }
        public string subject { get; set; }
        public string answer { get; set; }
        public string question { get; set; }
    }
}
