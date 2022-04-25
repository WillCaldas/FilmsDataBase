using AutoMapper;
using FDB.UsersAPI.Data.Dtos;
using FDB.UsersAPI.Models;
using FDB.UsersAPI.Services;
using Microsoft.AspNetCore.Identity;

namespace FDB.UsersAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<User, IdentityUser>();
        }
    }
}
