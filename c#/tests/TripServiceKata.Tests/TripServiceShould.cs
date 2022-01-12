using System.Collections.Generic;
using TripServiceKata.Entity;
using TripServiceKata.Service;
using Xunit;

namespace TripServiceKata.Tests
{
    public class TripServiceShould
    {
        [Fact]
        public void Get_trips_by_user()
        {
            var tripList = new List<Trip>();
            var userSessionFake = new UserSessionFake();
            var service = new TripService(tripList, userSessionFake);
            var user = new User();

            var resultTripList = service.GetTripsByUser(user);

            Assert.NotNull(resultTripList);
        }
    }

    public class UserSessionFake : IUserSession
    {
        public User GetLoggedUser()
        {
            return new User();
        }

        public bool IsUserLoggedIn(User user)
        {
            return true;
        }
    }
}
