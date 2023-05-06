using Travel_Agency.Data;
using Travel_Agency.Models.Entities;

namespace Travel_Agency.Services.Implementations {
    public class TravelRoutesService : ICRUDService<TravelRoute> {
        private readonly DatabaseContext _databaseContext;

        public TravelRoutesService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Task<TravelRoute> Create(TravelRoute value) {
            throw new NotImplementedException();
        }

        public Task<TravelRoute> Delete(TravelRoute value) {
            throw new NotImplementedException();
        }

        public Task<TravelRoute> Read(TravelRoute value) {
            throw new NotImplementedException();
        }

        public Task<TravelRoute> Update(TravelRoute value) {
            throw new NotImplementedException();
        }
    }
}
