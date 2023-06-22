using Microsoft.EntityFrameworkCore;
using Travel_Agency.Data;
using Travel_Agency.Models.Entities;
using Travel_Agency.Models.In;
using Travel_Agency.Models.Out;

namespace Travel_Agency.Services.Implementations {
    public class VehicleService : IVehicleService {
        private readonly DatabaseContext _databaseContext;

        public VehicleService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<dynamic> Create(VehicleIn value)
        {
            try
            {
                if (string.IsNullOrEmpty(value.Name)) throw new Exception("Vehicle's name is missing.");
                if (value.TheYearOfProduction < 1970 || value.TheYearOfProduction > 2023)
                    throw new Exception("Vehicle's year of production need to be between 1970 and 2023.");
                if (string.IsNullOrEmpty(value.Description)) throw new Exception("Vehicle's description is missing.");
                if (value.Seats < 0) throw new Exception("Vehicle's seats must be greater than 0.");
                var vehicle = new Vehicle { Name = value.Name, TheYearOfProduction = value.TheYearOfProduction, Description = value.Description, Seats = value.Seats};
                _databaseContext.Vehicles.Add(vehicle);
                await _databaseContext.SaveChangesAsync();
                var vehicleOut = new VehicleOut(vehicle.Id, vehicle.Name, vehicle.TheYearOfProduction, vehicle.Description, vehicle.Seats);
                return vehicleOut;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<dynamic> Read()
        {
            try
            {
                var vehicles = await _databaseContext.Vehicles.ToListAsync();
                if (vehicles.Count == 0) throw new Exception("There's no vehicles in database.");
                return vehicles;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<dynamic> Delete(int id)
        {
            try
            {
                var vehicle = await _databaseContext.Vehicles.FindAsync(id);
                if (vehicle == null) throw new Exception("There's no vehicle with that ID in database.");
                _databaseContext.Remove(vehicle);
                await _databaseContext.SaveChangesAsync();
                return $"The vehicle with ID {id} has been successfully deleted.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
