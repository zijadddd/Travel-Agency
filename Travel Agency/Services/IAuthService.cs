using Travel_Agency.Models.Entities;
using Travel_Agency.Models.In;
using Travel_Agency.Models.Out;

namespace Travel_Agency.Services
{
    public interface IAuthService
    {
        Task<dynamic> Register(UserIn request);
        Task<dynamic> Login(UserAuthInfoIn request);
    }
}
