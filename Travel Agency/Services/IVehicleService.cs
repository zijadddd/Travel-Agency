using Travel_Agency.Models.In;

namespace Travel_Agency.Services;

public interface IVehicleService
{
    Task<dynamic> Create(VehicleIn value);
    Task<dynamic> Read();
    Task<dynamic> Delete(int id);
}