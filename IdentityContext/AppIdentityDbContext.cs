using Microsoft.AspNet.Identity.EntityFramework;
using Users.Model;

namespace IdentityContext
{
   public class AppIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
       public AppIdentityDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

       public static AppIdentityDbContext Create()
        {
            return new AppIdentityDbContext();
        }
    }
}
