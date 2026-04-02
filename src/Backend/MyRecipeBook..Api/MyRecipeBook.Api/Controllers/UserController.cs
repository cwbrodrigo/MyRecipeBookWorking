using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Application.UseCases.DependencyInjection;
using MyRecipeBook.Comunication.Requests;
using MyRecipeBook.Comunication.Responses;
namespace MyRecipeBook.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRegisterUserUseCase _useCase;
        public UserController(IRegisterUserUseCase useCase)
        {
            _useCase = useCase;
        }
        [HttpPost("User")]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
        public IActionResult Register(RequestsRegisterUserJson request)
        {

            var result = _useCase.Execute(request);

            // Implementation for retrieving user profile

            return Created(string.Empty, result);

        }
    }
}
