using Microsoft.AspNet.Identity.EntityFramework;

namespace E_Ticaret_Programi.Identity
{
    public class ApplicationUser:IdentityUser
    {
        public string  Name { get; set; }
        public string Surname { get; set; }
    }
}