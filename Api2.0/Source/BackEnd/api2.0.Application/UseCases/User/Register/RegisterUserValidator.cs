using Ap2._0.Communication.Requests;
using Ap2._0.Communication.Responses;
using Api2._0.Exceptions;
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
            RuleFor(user=> user.Name).NotEmpty().WithMessage(ResourceMessages.NAME_EMPTY);
            RuleFor(user=> user.Email).NotEmpty().WithMessage(ResourceMessages.EMAIL_EMPTY);
            RuleFor(user => user.Email).EmailAddress().WithMessage(ResourceMessages.EMAIL_INVALID);
            RuleFor(user=> user.Password.Length).GreaterThanOrEqualTo(6).WithMessage(ResourceMessages.PASSWORD_INVALID);
        }
    }
}
