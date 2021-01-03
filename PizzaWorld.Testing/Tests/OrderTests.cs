using Xunit;
using PizzaWorld.Domain.Models;
using System.Linq;

namespace PizzaWorld.Testing
{
    public class OrderTests
    {

        private readonly Order TestOrder;

        public OrderTests()
        {
            TestOrder = new Order();
        }

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

        //Test it can make Meat pizza
        [Fact]
        private void TestCanMakeMeatPizza()
        {
            //arrange
            Order TestOrder = new Order();
            //act
            TestOrder.MakeMeatPizza();
            //assert
            Assert.IsType<MeatPizza>(TestOrder.Pizzas.Last());
        }

        [Fact]
        private void TestCanMakeGreekPizza()
        {
            //arrange
            Order TestOrder = new Order();
            //act
            TestOrder.MakeGreekPizza();
            //assert
            Assert.IsType<GreekPizza>(TestOrder.Pizzas.Last());
        }
    
        [Fact]
        private void TestCanMakeHawaiianPizza()
        {
            //arrange
            Order TestOrder = new Order();
            //act
            TestOrder.MakeHawaiianPizza();
            //assert
            Assert.IsType<HawaiianPizza>(TestOrder.Pizzas.Last());
        }

        //Test validatePriceLimit
        //small greek pizza is $10
        [Fact]
        private void TestValidateUnderPriceLimitAt250()
        {
            //arrange
            Order TestOrder = new Order();
            //act
            for(int i = 0; i < 25; i++)
            {
                TestOrder.MakeGreekPizza();
            }
            //asset
            Assert.Equal(25, TestOrder.Pizzas.Count());
        }
        [Fact]
        private void TestValidateUnderPriceLimitAfter250()
        {
            //arrange
            Order TestOrder = new Order();
            //act
            for(int i = 0; i < 26; i++)
            {
                TestOrder.MakeGreekPizza();
            }
            //asset
            Assert.Equal(25, TestOrder.Pizzas.Count);
        }
    
    }
}