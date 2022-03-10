using CUST.Repository.Abstract;
using CUST.Repository.Concrete;

namespace CUST.API.Configuration
{
    public static class RepositoryConfig
    {
        public static void Register(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
        }
    }
}
