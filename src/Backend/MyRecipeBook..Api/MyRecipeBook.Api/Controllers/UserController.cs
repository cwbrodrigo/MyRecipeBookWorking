using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Application.Services.AutoMapper;
using MyRecipeBook.Application.UseCases.User.register;
using MyRecipeBook.Comunication.Requests;
using MyRecipeBook.Comunication.Responses;

namespace MyRecipeBook.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IMapper Mapper { get; set; }
        public IPasswordEncripter Encripter { get; set; }

        [HttpPost("User")]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
        public IActionResult Register(RequestsRegisterUserJson request)
        {
            var useCase = new RegisterUserUseCase(Mapper, Encripter);

            var result = useCase.Execute(request);

            // Implementation for retrieving user profile

            return Created(string.Empty, result);

        }
    }
}
