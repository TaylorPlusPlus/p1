using Xunit;
using PizzaWorld.Domain.Models;
using System;
using System.Linq;
using PizzaWorld.Domain.Factories;

namespace PizzaWorld.Testing
{
    public class CrustsTests
    {
        GenericToppingFactory Topping = new GenericToppingFactory();

        [Fact]
        public void TestFetaExists()
        {
            // create
            var FetaTopping = Topping.Make<Feta>();
            decimal Price = 0;
            string Name = "";
            // act
            Price = FetaTopping.Price;
            Name = FetaTopping.Name;

            // assert
            Assert.IsType<Feta>(FetaTopping);
            Assert.NotNull(FetaTopping);
            Assert.Equal("Feta", Name);
            Assert.Equal(1.6m, Price);
        }

        
        [Fact]
        public void TestHamExists()
        {
            // create
            var FetaTopping = Topping.Make<Ham>();
            decimal Price = 0;
            string Name = "";
            // act
            Price = FetaTopping.Price;
            Name = FetaTopping.Name;

            // assert
            Assert.IsType<Ham>(FetaTopping);
            Assert.NotNull(FetaTopping);
            Assert.Equal("Ham", Name);
            Assert.Equal(1.75m, Price);
        }

        [Fact]
        public void TestOlivesExists()
        {
            // create
            var FetaTopping = Topping.Make<Olives>();
            decimal Price = 0;
            string Name = "";
            // act
            Price = FetaTopping.Price;
            Name = FetaTopping.Name;

            // assert
            Assert.IsType<Olives>(FetaTopping);
            Assert.NotNull(FetaTopping);
            Assert.Equal("Olives", Name);
            Assert.Equal(1.40m, Price);
        }

         [Fact]
        public void TestPineappleExists()
        {
            // create
            var FetaTopping = Topping.Make<PineApple>();
            decimal Price = 0;
            string Name = "";
            // act
            Price = FetaTopping.Price;
            Name = FetaTopping.Name;

            // assert
            Assert.IsType<PineApple>(FetaTopping);
            Assert.NotNull(FetaTopping);
            Assert.Equal("Pineapple", Name);
            Assert.Equal(1.25m, Price);
        }

        [Fact]
        public void TestSausageExists()
        {
            // create
            var FetaTopping = Topping.Make<Sausage>();
            decimal Price = 0;
            string Name = "";
            // act
            Price = FetaTopping.Price;
            Name = FetaTopping.Name;

            // assert
            Assert.IsType<Sausage>(FetaTopping);
            Assert.NotNull(FetaTopping);
            Assert.Equal("Sausage", Name);
            Assert.Equal(1.50m, Price);
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
