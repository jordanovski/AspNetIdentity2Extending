using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AspNetIdentity2Extending.Models
{
    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "CreatedDate")]
        public DateTime? CreatedDate { get; set; }

        public IEnumerable<SelectListItem> RolesList { get; set; }
    }
}