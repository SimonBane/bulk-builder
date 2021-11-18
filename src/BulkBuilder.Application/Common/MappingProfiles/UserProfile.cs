using System.Linq;
using System.Security.Claims;
using AutoMapper;
using BulkBuilder.Application.Users;
using BulkBuilder.Domain.Entities;

namespace BulkBuilder.Application.Common.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ClaimsPrincipal, UserContext>()
                .ForMember(uc => uc.Email, opts =>
                    opts.MapFrom(cp => cp.Claims.FirstOrDefault(c => c.Type == "https://example.com/email").Value))
                .ForMember(uc => uc.Sub, opts =>
                    opts.MapFrom(cp => cp.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value));

            CreateMap<ClaimsPrincipal, User>()
                .ForMember(u => u.Email, opts =>
                    opts.MapFrom(cp => cp.Claims.FirstOrDefault(c => c.Type == "https://example.com/email").Value))
                .ForMember(u => u.Sub, opts =>
                    opts.MapFrom(cp => cp.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value));
        }
    }
}