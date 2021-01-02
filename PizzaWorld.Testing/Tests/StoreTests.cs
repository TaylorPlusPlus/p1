using Xunit;
using PizzaWorld.Domain.Models;

namespace PizzaWorld.Testing
{
    public class StoreTests
    {

        [Fact]
        public void TestStoreExists()
        {
            // create
            var store = new Store();

            // act
            var store2 = store;

            // assert
            Assert.IsType<Store>(store2);
            Assert.NotNull(store2);
        }
    }
    
}
