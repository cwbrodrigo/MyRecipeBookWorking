using Mapster;
using MyRecipeBook.Comunication.Requests;

namespace MyRecipeBook.Application.Services.Mappings
{
    public class MapConfigurations
    {
        public static void Configure()
        {
            TypeAdapterConfig<RequestsRegisterUserJson, Domain.Entities.User>.NewConfig()
                  .Ignore(x => x.Password);
            //TypeAdapterConfig<RequestsRegisterWorkItemJson, Domain.Entities.User>.NewConfig()
            //      .Ignore(x => x.ConfirmPassword);
        }
    }
}
