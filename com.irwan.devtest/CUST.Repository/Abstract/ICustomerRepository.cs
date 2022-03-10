using CUST.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUST.Repository.Abstract
{
    public interface ICustomerRepository : IAsyncRepository<Customers>
    {
    }
}
