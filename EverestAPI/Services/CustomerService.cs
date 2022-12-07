using EverestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EverestAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly List<CustomerModel> customersList = new();

        private void CustomerDuplicate(CustomerModel model) 
        {
            if (customersList.Any(customer => customer.Cpf == model.Cpf))
                throw new ArgumentException("This Cpf already exists");

            if (customersList.Any(customer => customer.Email == model.Email))
                throw new ArgumentException("This email already exists");
        }
        public long Create(CustomerModel customer)
        {
            CustomerDuplicate(customer);

            customer.Id = customersList.LastOrDefault()?.Id + 1 ?? 1;

            customersList.Add(customer);

            return customer.Id;
        }
        public void Update(CustomerModel updateModel, long id)
        {
            CustomerDuplicate(updateModel);

            updateModel.Id = id;

            var index = customersList.FindIndex(customer => customer.Id == updateModel.Id);

            if (index == -1)
                throw new ArgumentNullException($"Customer with id: {updateModel.Id} not found");

            customersList[index] = updateModel;
        }
        public CustomerModel GetById(long id) 
        {
            var response = customersList.FirstOrDefault(customer => customer.Id == id);

            if (response == null) throw new ArgumentNullException($"Customer for id: {id} was not found");

            return response;
        }
        public void Delete(long Id)
        {
            var customer = GetById(Id);

            customersList.Remove(customer);
        }
        public IEnumerable<CustomerModel> GetAll() 
        { 
            return customersList; 
        }      
    }
}
