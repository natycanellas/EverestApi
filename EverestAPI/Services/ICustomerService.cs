using EverestAPI.Models;

namespace EverestAPI.Services
{
    public interface ICustomerService
    {
        void Create(CustomerModel model);
        void Update(CustomerModel model);
        void Delete(long id);
        IEnumerable<CustomerModel> GetAll();
        CustomerModel? GetById(long id);
    }
}
