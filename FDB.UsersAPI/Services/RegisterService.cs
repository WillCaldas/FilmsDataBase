using AutoMapper;
using FDB.UsersAPI.Data.Dtos;
using FDB.UsersAPI.Models;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace FDB.UsersAPI.Services
{
    public class RegisterService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _manager;

        public RegisterService(IMapper mapper, UserManager<IdentityUser<int>> manager)
        {
            _mapper = mapper;
            _manager = manager;
        }

        public Result RegisterUser(CreateUserDto newUserDto)
        {
            User newUser = _mapper.Map<User>(newUserDto);
            IdentityUser<int> userIdentity = _mapper.Map<IdentityUser<int>>(newUserDto);
            var resultIdentity = _manager.CreateAsync(userIdentity, newUserDto.Password);

            if (resultIdentity.Result.Succeeded)
            {
                return Result.Ok();
            }

            return Result.Fail("Falha ao cadastrar usuário");
        }
    }
}
