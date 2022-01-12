using System.Collections.Generic;
using System.Linq;
using TripServiceKata.Entity;
using TripServiceKata.Exception;
using TripServiceKata.Service;

namespace TripServiceKata
{
    public class TripService
    {
        private readonly List<Trip> tripList;
        private readonly IUserSession userSession;
        private readonly ITripDAOWrapper tripDAOWrapper;

        public TripService(List<Trip> tripList, IUserSession userSession, ITripDAOWrapper tripDAOWrapper)
        {
            this.tripList = tripList;
            this.userSession = userSession;
            this.tripDAOWrapper = tripDAOWrapper;
        }

        public List<Trip> GetTripsByUser(User user)
        {
            var tripList = this.tripList;
            var loggedUser = userSession.GetLoggedUser();
            var isFriend = false;
            if (loggedUser == null) 
                throw new UserNotLoggedInException();
            if (Enumerable.Contains(user.GetFriends(), loggedUser))
            {
                isFriend = true;
            }

            if (isFriend)
            {
                tripList = tripDAOWrapper.FindTripsByUser(user);
            }

            return tripList;

        }
    }
}