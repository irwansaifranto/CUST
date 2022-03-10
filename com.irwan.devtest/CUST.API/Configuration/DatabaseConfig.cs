using CUST.Model;
using Microsoft.EntityFrameworkCore;

namespace CUST.API.Configuration
{
    public static class DatabaseConfig
    {
        public static void Register(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
