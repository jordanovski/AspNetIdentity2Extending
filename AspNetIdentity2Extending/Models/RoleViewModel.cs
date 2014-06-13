using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity2Extending.Models
{
    public class RoleViewModel
    {
        public string Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "RoleName")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}