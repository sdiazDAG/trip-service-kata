using System.Collections.Generic;
using TripServiceKata.Entity;
using TripServiceKata.Service;
using Xunit;

namespace TripServiceKata.Tests
{
    public class TripServiceShould
    {
        [Fact]
        public void Call_Get_logued_user()
        {
            var tripList = new List<Trip>();
            var userSession = UserSession.GetInstance();
            var service = new TripService(tripList, userSession);
            var user = new User();

            var resultTripList = service.GetTripsByUser(user);
        }
    }
}
