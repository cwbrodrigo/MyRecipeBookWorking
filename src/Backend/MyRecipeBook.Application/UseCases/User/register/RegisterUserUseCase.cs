using MyRecipeBook.Comunication.Requests;
using MyRecipeBook.Comunication.Responses;
using MyRecipeBook.Exceptions.ExceptionsBase;

namespace MyRecipeBook.Application.UseCases.User.register
{
    public class RegisterUserUseCase
    {
        public ResponseRegisteredUserJson Execute(RequestsRegisterUserJson requests)
        {
            // validar a request
            Validate(requests);

            // mapear a request em uma entidade
            var user = new Domain.Entities.User()
            {
                Name = requests.Name,
                Email = requests.Email,
                Password = requests.Password
            };

            // Criptografar a senha

            // Salvar no BD

            return new ResponseRegisteredUserJson()
            {
                Name = requests.Name,
            };
        }

        public void Validate(RequestsRegisterUserJson requests)
        {
            var validator = new RegisterUserValidator();

            var result = validator.Validate(requests);

            if (result.IsValid == false)
            {
                var errorMessage = result.Errors.Select(x => x.ErrorMessage).ToList();

                //validator.ValidateAndThrow(requests);

                throw new ErrorOnValidationException(errorMessage);

            }
        }
    }
}
