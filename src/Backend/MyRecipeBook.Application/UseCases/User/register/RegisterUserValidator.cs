using FluentValidation;
using MyRecipeBook.Comunication.Requests;
using MyRecipeBook.Exceptions;

namespace MyRecipeBook.Application.UseCases.User.register
{
    public class RegisterUserValidator : AbstractValidator<RequestsRegisterUserJson>
    {
        public RegisterUserValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(ResourceMessagesExceptions.NAME_EMPTY)
                .MaximumLength(100).WithMessage(ResourceMessagesExceptions.NAME_MAX_100);
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(ResourceMessagesExceptions.EMPTY_EMAIL)
                .EmailAddress().WithMessage(ResourceMessagesExceptions.INVALID_EMAIL);
            RuleFor(x => x.Password.Length).
                GreaterThanOrEqualTo(6)
                .WithMessage(ResourceMessagesExceptions.PASSWORD_MUST_GREATHER_THAN_6_CHARACTERS)
                .NotEmpty().WithMessage(ResourceMessagesExceptions.PASSWORD_EMPTY);
        }
    }
}
