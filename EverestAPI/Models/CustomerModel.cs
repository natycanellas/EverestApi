using System;

namespace EverestAPI.Models
{
    public class CustomerModel : IModel
    {
        public CustomerModel(
            string fullName, 
            string email, 
            string emailConfirmation, 
            string cpf, 
            string cellphone, 
            DateTime dateOfBirth, 
            bool emailSms, 
            bool whatsapp, 
            string country, 
            string city,
            string postalCode, 
            string address
        )
        {
            FullName = fullName;
            Email = email;
            EmailConfirmation = emailConfirmation;
            Cpf = cpf.CpfFormatter();
            Cellphone = cellphone;
            DateOfBirth = dateOfBirth;
            EmailSms = emailSms;
            Whatsapp = whatsapp;
            Country = country;
            City = city;
            PostalCode = postalCode;
            Address = address;
        }

        public string FullName { get; set; }
        public string Email { get; set; }
        public string EmailConfirmation { get; set; }
        public string Cpf { get; set; }
        public string Cellphone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool EmailSms { get; set; }
        public bool Whatsapp { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
        public long Id { get; set; }
    }
}
