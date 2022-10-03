namespace dating_app.api.Service
{
    public interface ITokenService
    {
        string createToken(string username);
    }
}