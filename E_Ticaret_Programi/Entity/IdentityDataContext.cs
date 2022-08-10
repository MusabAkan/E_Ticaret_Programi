

using E_Ticaret_Programi.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace E_Ticaret_Programi.Entity
{
    public class IdentityDataContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityDataContext() : base("dataConnection")
        {
           
        }
    
    }
}