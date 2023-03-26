using Travel_Agency.Models.Entities;
using Travel_Agency.Models.In;
using Travel_Agency.Models.Out;

namespace Travel_Agency.Services
{
    public interface IAuthService
    {
        Task<UserOut> Register(UserIn request);
        Task<UserAuthInfo> Login(UserAuthInfoIn request);
    }
}
