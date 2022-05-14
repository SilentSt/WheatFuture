using AutoMapper;

using Wheat.Models.Entities;
using Wheat.Models.Responses;

namespace Wheat.Models
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<WIdentityUser, UserDto>();
        }
    }
}
