using System.Collections.Generic;
using TripServiceKata.Entity;

namespace TripServiceKata
{
    public interface ITripDAOWrapper
    {
        List<Trip> FindTripsByUser(User user);
    }
}