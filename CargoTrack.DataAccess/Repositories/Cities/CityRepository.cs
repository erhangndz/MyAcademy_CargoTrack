using CargoTrack.DataAccess.Context;
using CargoTrack.DataAccess.Repositories.GenericRepositories;
using CargoTrack.Entity.Entities;

namespace CargoTrack.DataAccess.Repositories.Cities
{
    public class CityRepository(AppDbContext context) : GenericRepository<City>(context), ICityRepository
    {
       
    }
}
