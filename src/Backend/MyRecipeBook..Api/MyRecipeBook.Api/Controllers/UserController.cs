using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Application.UseCases.User.register;
using MyRecipeBook.Comunication.Requests;
using MyRecipeBook.Comunication.Responses;

namespace MyRecipeBook.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost("User")]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
        public IActionResult Register(RequestsRegisterUserJson request)
        {
            var useCase = new RegisterUserUseCase();

            var result = useCase.Execute(request);

            // Implementation for retrieving user profile

            return Created(string.Empty, result);

        }
    }
}
