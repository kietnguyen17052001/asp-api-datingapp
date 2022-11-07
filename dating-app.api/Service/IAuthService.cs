using dating_app.api.DTOs;

namespace dating_app.api.Service
{
    public interface IAuthService
    {
        string login(AuthUserDto authUserDto);
        string register(RegisterUserDto registerUserDto);
    }
}