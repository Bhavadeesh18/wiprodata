namespace JWTExampledotnet.Models
{
    public interface IAuthservice
    {
        Task<string> Authenticate(string username, string password);
    }
}
