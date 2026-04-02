using AutoMapper;
using MyRecipeBook.Comunication.Requests;
using MyRecipeBook.Domain.Entities;

namespace MyRecipeBook.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RequestsRegisterUserJson, User>()
                .ForMember(opt => opt.Password, opt => opt.Ignore());
        }
    }
}