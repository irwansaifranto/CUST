using CUST.Model;
using Microsoft.AspNetCore.Identity;

namespace CUST.API.Configuration
{
    public static class IdentityConfig
    {
        public static void Register(this WebApplicationBuilder builder)
        {
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}
