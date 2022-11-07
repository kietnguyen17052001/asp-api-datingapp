using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using dating_app.api.Data.Entity;
using dating_app.api.DTOs;
using dating_app.api.Repository;

namespace dating_app.api.Service
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository userRepository;
        private readonly ITokenService tokenService;
        public AuthService(IUserRepository _userRepository, ITokenService _tokenService)
        {
            userRepository = _userRepository;
            tokenService = _tokenService;
        }

        public string login(AuthUserDto authUserDto)
        {
            authUserDto.username = authUserDto.username.ToLower();
            var currentUser = userRepository.getUserByUsername(authUserDto.username);
            if (currentUser == null)
            {
                throw new UnauthorizedAccessException("Username is invalid!");
            }
            using var hmac = new HMACSHA512(currentUser.passwordSalt);
            var passwordByte = hmac.ComputeHash(Encoding.UTF8.GetBytes(authUserDto.password));
            for (int i = 0; i < currentUser.passwordHash.Length; i++)
            {
                if (currentUser.passwordHash[i] != passwordByte[i])
                {
                    throw new UnauthorizedAccessException("Password is invalid!");
                }
            }
            return tokenService.createToken(currentUser.username);
        }

        public string register(RegisterUserDto registerUserDto)
        {
            registerUserDto.username = registerUserDto.username.ToLower();
            var currentUser = userRepository.getUserByUsername(registerUserDto.username);
            if (currentUser != null)
            {
                throw new BadHttpRequestException("Username is already exists!");
            }
            else
            {
                using var hmac = new HMACSHA512();
                var passwordByte = Encoding.UTF8.GetBytes(registerUserDto.password);
                var newUser = new UserEntity
                {
                    username = registerUserDto.username,
                    passwordSalt = hmac.Key,
                    passwordHash = hmac.ComputeHash(passwordByte)
                };
                userRepository.createUser(newUser);
                userRepository.isSaveChanges();
                return tokenService.createToken(newUser.username);
            }
        }
    }
}