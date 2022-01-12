using System.Collections.Generic;
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
            List<Trip> tripList = this.tripList;
            User loggedUser = userSession.GetLoggedUser();
            bool isFriend = false;
            if (loggedUser != null)
            {
                foreach (User friend in user.GetFriends())
                {
                    if (friend.Equals(loggedUser))
                    {
                        isFriend = true;
                        break;
                    }
                }

                if (isFriend)
                {
                    tripList = tripDAOWrapper.FindTripsByUser(user);
                }

                return tripList;
            }
            else
            {
                throw new UserNotLoggedInException();
            }
        }
    }
}