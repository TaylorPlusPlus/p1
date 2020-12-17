using Xunit;
using PizzaWorld.Domain.Models;
namespace PizzaWorld.Testing
{

    public class PizzaTests
    {
        [Fact]
        public void TestPizzaExists()
        {
            // create
            var pizza = new Pizza();
            // act
            var check = pizza;
            // assert
            Assert.IsType<Pizza>(check);
            Assert.NotNull(check);
        }


    }
}