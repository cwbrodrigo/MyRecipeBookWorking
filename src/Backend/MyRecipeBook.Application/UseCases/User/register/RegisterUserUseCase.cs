using AutoMapper;
using MyRecipeBook.Application.Services.AutoMapper;
using MyRecipeBook.Application.Services.Cryptography;
using MyRecipeBook.Application.UseCases.DependencyInjection;
using MyRecipeBook.Comunication.Requests;

namespace MyRecipeBook.Application.UseCases.User.register
{
    public class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IMapper _mapper;
        private readonly IPasswordEncripter _encripter;

        public RegisterUserUseCase(IMapper mapper, IPasswordEncripter encripter)
        {
            _mapper = mapper;
            _encripter = encripter;
        }


        public Domain.Entities.User Execute(RequestsRegisterUserJson requests)
        {
            if (_mapper == null)
                throw new Exception("Mapper não foi injetado");
            // validar a request
            var Criptografia = new PasswordEncripter();

            //var user = new AutoMapper.Mapper(new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<RequestsRegisterUserJson, Domain.Entities.User>();
            //})).Map<Domain.Entities.User>(requests);

            var user = _mapper.Map<Domain.Entities.User>(requests);
            user.Password = _encripter.Encrypt(requests.Password);
            // Criptografar a senha

            Validate(requests);
            // mapear a request em uma entidade

            // Salvar no BD

            return user;
        }

        public void Validate(RequestsRegisterUserJson requests)
        {
            try
            {
                var validator = new RegisterUserValidator();

                var result = validator.Validate(requests);

                if (result.IsValid == false)
                {
                    var errorMessage = result.Errors.Select(x => x.ErrorMessage).ToList();

                }
            }
            catch (ArgumentException ex)
            {
                throw;
            }
        }
    }
}

