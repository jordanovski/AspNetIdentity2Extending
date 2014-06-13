using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Identity.Models
{
    public class ApplicationRole : IdentityRole
    {
        public String Description { get; set; }
    }
}
