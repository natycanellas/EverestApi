using EverestAPI.Models;
using System.Collections.Generic;

namespace EverestAPI.Services
{
    public interface ICustomerService
    {
        long Create(CustomerModel model);
        void Update(CustomerModel model, long id);
        void Delete(long id);
        IEnumerable<CustomerModel> GetAll();
        CustomerModel GetById(long id);
    }
}
