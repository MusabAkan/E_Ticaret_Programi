using Microsoft.AspNet.Identity.EntityFramework;

namespace E_Ticaret_Programi.Identity
{
    public class ApplicationRole: IdentityRole
    {
        public string  Description { get; set; }
        public ApplicationRole()
        {

        }
        public ApplicationRole(string rolename, string description)
        {
            this.Description = description;
            
        }
    }
}