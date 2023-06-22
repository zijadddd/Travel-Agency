using Travel_Agency.Data;
using Travel_Agency.Models.In;

namespace Travel_Agency.Services.Implementations {
    public class TravelRoutesService : ICRUDService<TravelRouteIn> {
        private readonly DatabaseContext _databaseContext;

        public TravelRoutesService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Task<dynamic> Create(TravelRouteIn value)
        {
            throw new NotImplementedException();
        }

        public Task<dynamic> Read(TravelRouteIn value)
        {
            throw new NotImplementedException();
        }

        public Task<dynamic> Update(TravelRouteIn value)
        {
            throw new NotImplementedException();
        }

        public Task<dynamic> Delete(TravelRouteIn value)
        {
            throw new NotImplementedException();
        }
    }
}
