using BlazedCosmos.Models;

namespace BlazedCosmos.Services.Interfaces
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        void Register(User user);
    }
}