using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Identity.Model
{
    public class ApplicationRole : IdentityRole
    {
        public String Description { get; set; }
    }
   
}
