using System.ComponentModel.DataAnnotations;

namespace bankwebApi.Models
{
    public class user
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string email { get; set; }

        public string password { get; set; }
        public int status { get; set; }
        public int is_admin { get; set; }
    }


}
