using System.Collections.Generic;
using TripServiceKata.Entity;
using TripServiceKata.Service;
using Xunit;

namespace TripServiceKata.Tests
{
    public class TripServiceShould
    {
        private readonly User user;
        private readonly List<Trip> tripList;
        private readonly UserSessionFake userSessionFake;
        private readonly TripDAOWrapperFake tripDAOWrapper;
        private readonly TripService tripService;

        public TripServiceShould()
        {
            tripList = new List<Trip>();
            userSessionFake = new UserSessionFake();
            tripDAOWrapper = new TripDAOWrapperFake();
            tripService = new TripService(tripList, userSessionFake, tripDAOWrapper);
            user = userSessionFake.GetLoggedUser();
        }

        [Fact]
        public void Get_trips_by_user()
        {
            var resultTripList = tripService.GetTripsByUser(user);

            Assert.NotNull(resultTripList);
        }

        [Fact]
        public void Get_trips_by_user_when_user_logged_is_friend()
        {
            user.AddFriend(user);

            var resultTripList = tripService.GetTripsByUser(user);

            Assert.NotNull(resultTripList);
        }
    }

    public class TripDAOWrapperFake : ITripDAOWrapper
    {
        public List<Trip> FindTripsByUser(User user)
        {
            return new List<Trip>();
        }
    }

    public class UserSessionFake : IUserSession
    {
        private readonly User user;

        public UserSessionFake()
        {
            user = new User();
        }

        public User GetLoggedUser()
        {
            return user;
        }

        public bool IsUserLoggedIn(User user)
        {
            return true;
        }
    }
}
