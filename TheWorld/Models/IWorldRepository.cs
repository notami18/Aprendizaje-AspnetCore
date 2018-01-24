using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheWorld.Models
{
    public interface IWorldRepository
    {
        IEnumerable<Trip> GetAllTrips();
        IEnumerable<Trip> GetTripsByUsername(string usename);
        Trip GetTripByName(string tripName);
        Trip GetUserTripByName(string tripName, string username);   

        void AddTrip(Trip trip);
        void addStop(string tripName, Stop newStop, string username);

        Task<bool> SaveChangesAsync();
        
    }
}