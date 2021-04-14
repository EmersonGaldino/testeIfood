using System.ComponentModel.DataAnnotations;

namespace ifood.test.galdino.api.Models.User
{
    public class UserViewModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
