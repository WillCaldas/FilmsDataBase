using FDB.UsersAPI.Data.Request;
using FDB.UsersAPI.Models;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace FDB.UsersAPI.Services
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _sign;
        private TokenService _token;

        public LoginService(SignInManager<IdentityUser<int>> sign, TokenService token)
        {
            _sign = sign;
            _token = token;
        }

        public Result LoginUser(LoginRequest request)
        {
            var result = _sign.PasswordSignInAsync(request.UserName, request.Password, false, false);

            if (result.Result.Succeeded)
            {
                var identityUser = _sign
                    .UserManager
                    .Users
                    .FirstOrDefault(user => user.NormalizedUserName == request.UserName.ToUpper());

                Token token = _token.CreateToken(identityUser);

                return Result.Ok().WithSuccess(token.Value);
            }

            return Result.Fail("Falha ao Autenticar!");
        }
    }
}
