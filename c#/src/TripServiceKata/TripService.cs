using System.Collections.Generic;
using TripServiceKata.Entity;
using TripServiceKata.Exception;
using TripServiceKata.Service;

namespace TripServiceKata
{
    public class TripService
    {
        private readonly List<Trip> tripList;
        private readonly UserSession userSession;

        public TripService(List<Trip> tripList, UserSession userSession)
        {
            this.tripList = tripList;
            this.userSession = userSession;
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
                    tripList = TripDAO.FindTripsByUser(user);
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