using Xunit;
using PizzaWorld.Domain.Models;
using System;
using System.Linq;

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

        [Fact]
        public void CheckIfOrderPlacedWithinWeekTrue()
        {
            //arrange 
            Store TestStore = new Store();
            Order TestOrder = new Order();
            bool Answer;
            //act 
            TestOrder.PurchaseDate = DateTime.Now;
            TestStore.Orders.Add(TestOrder);
            Answer = TestStore.CheckIfOrderPlacedWithinWeek(
                TestStore.Orders.Last()
            );

            //asset
            Assert.True(Answer);
        }

        [Fact]
        public void CheckIfOrderPlacedWithinWeekFalse()
        {
            //arrange 
            Store TestStore = new Store();
            Order TestOrder = new Order();
            bool Answer;
            //act 
            TestOrder.PurchaseDate = new DateTime(2000,1,1,8,8,8);
            TestStore.Orders.Add(TestOrder);
            Answer = TestStore.CheckIfOrderPlacedWithinWeek(
                TestStore.Orders.Last()
            );

            //asset
            Assert.False(Answer);
        }

    }
    
}
