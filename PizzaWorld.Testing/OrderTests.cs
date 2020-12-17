using Xunit;
using PizzaWorld.Domain.Models;

namespace PizzaWorld.Testing
{
    public class OrderTests
    {
        [Fact]
        private void TestOrderExists()
        {
            // arrange
            Order sut = new Order();
            
            // act
            Order actual = sut;
            // assert
            Assert.IsType<Order>(actual);
            Assert.NotNull(actual);
        }
    }
}