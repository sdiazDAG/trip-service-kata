using System.Collections.Generic;
using TripServiceKata.Entity;
using TripServiceKata.Service;

namespace TripServiceKata
{
    public interface ITripDAOWrapper
    {
        List<Trip> FindTripsByUser(User user);
    }

    public class TripDAOWrapper : ITripDAOWrapper
    {
        public TripDAOWrapper()
        {
        }

        public List<Trip> FindTripsByUser(User user)
        {
            return TripDAO.FindTripsByUser(user);
        }
    }
}