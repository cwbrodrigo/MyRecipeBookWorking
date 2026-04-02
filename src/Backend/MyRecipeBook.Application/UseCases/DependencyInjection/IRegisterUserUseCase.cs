using MyRecipeBook.Comunication.Requests;

namespace MyRecipeBook.Application.UseCases.DependencyInjection
{
    public interface IRegisterUserUseCase
    {
        public Domain.Entities.User Execute(RequestsRegisterUserJson requests);
        void Validate(RequestsRegisterUserJson requests);
    }
}
