
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace InsuranceWebApi.Helpers
{
    public class RolesInitializer
    {
        public static async Task AddRolesToDataBase(IApplicationBuilder applicationBuilder)
        {
            using (var scope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if(!await roleManager.RoleExistsAsync(Roles.Admin))
                {
                    await roleManager.CreateAsync(new IdentityRole(Roles.Admin));
                }
                if (!await roleManager.RoleExistsAsync(Roles.Employee))
                {
                    await roleManager.CreateAsync(new IdentityRole(Roles.Employee));
                }
                if (!await roleManager.RoleExistsAsync(Roles.Agent))
                {
                    await roleManager.CreateAsync(new IdentityRole(Roles.Agent));
                }
                if (!await roleManager.RoleExistsAsync(Roles.Customer))
                {
                    await roleManager.CreateAsync(new IdentityRole(Roles.Customer));
                }
            }
        }
    }
}
