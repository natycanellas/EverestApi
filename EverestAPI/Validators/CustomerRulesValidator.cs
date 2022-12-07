using EverestAPI.Models;
using FluentValidation;
using System;
using System.Linq;

namespace EverestAPI.Validators
{
    public class CustomerRulesValidator : AbstractValidator<CustomerModel>
    {
        public CustomerRulesValidator()
        {
            RuleFor(customer => customer.FullName)
                .NotEmpty()
                .MinimumLength(5);

            RuleFor(customer => customer.Email).NotEmpty()
                .WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid Email format");

            RuleFor(customer => customer.Cpf)
                .NotEmpty()
                .Must(isCpfValid)
                .WithMessage("Cpf is not valid");

            RuleFor(customer => customer.DateOfBirth)
                .NotEmpty()
                .WithMessage("Date of birth must be informed")
                .Must(OverAgeCustomer).WithMessage("Customer must be at least 18 years old");

            RuleFor(customer => customer.Country)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(40);

            RuleFor(customer => customer.City)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(40);

            RuleFor(customer => customer.Cellphone)
                .NotEmpty()
                .MinimumLength(11)
                .MaximumLength(16);

            RuleFor(customer => customer.PostalCode)
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(9);
        }

        private static bool OverAgeCustomer(DateTime dateOfBirth)
        {
            return dateOfBirth <= DateTime.Now.AddYears(-18);
        }

        public bool isCpfValid(string cpf)
        {
            cpf = cpf.CpfFormatter();

            if (cpf.Length != 11)
                return false;

            if (cpf.All(character => character == cpf.First()))
                return false;

            int[] mult1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mult2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string digit;
            int sum;
            int rest;

            sum = 0;

            for (int i = 0; i < 9; i++)
                sum += Convert.ToInt32(cpf[i].ToString()) * mult1[i];

            rest = sum % 11;

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit = rest.ToString();

            sum = 0;

            for (int i = 0; i < 10; i++)
                sum += Convert.ToInt32(cpf[i].ToString()) * mult2[i];

            rest = sum % 11;

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit = digit + rest.ToString();

            return cpf.EndsWith(digit);
        }
    }
}
