using Xunit;
using PizzaWorld.Domain.Models;

namespace PizzaWorld.Testing
{
    public class UserTests
    {
        [Fact]
        public void TestUserExists()
        {
            //create
            var user = new User();
            //act
            var testUser = user;
            //assert
            Assert.IsType<User>(testUser);
            Assert.NotNull(testUser);
            Assert.NotSame(user,testUser);
        }
    }

}