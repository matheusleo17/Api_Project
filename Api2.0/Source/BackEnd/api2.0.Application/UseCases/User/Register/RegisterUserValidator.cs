using Ap2._0.Communication.Requests;
using Ap2._0.Communication.Responses;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api2._0.Application.UseCases.User.Register
{
    public class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
    {
        public RegisterUserValidator() 
        { 
            RuleFor(user=> user.Name).NotEmpty();
            RuleFor(user=> user.Email).NotEmpty();
            RuleFor(user => user.Email).EmailAddress();
            RuleFor(user=> user.Password.Length).GreaterThanOrEqualTo(6);
        }
    }
}
