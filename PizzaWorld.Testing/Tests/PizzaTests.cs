using Xunit;
using PizzaWorld.Domain.Models;
using PizzaWorld.Domain.Factories;
using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Testing
{

    public class PizzaTests
    {

        GenericPizzaFactory PizzaFactory = new GenericPizzaFactory();
        
        [Fact]
        public void TestMeatPizzaExists()
        {
            // create
            var MeatTest = PizzaFactory.Make<MeatPizza>();
            
            // act
            var Actual = MeatTest;

            // assert
            Assert.IsType<MeatPizza>(Actual);
            Assert.NotNull(Actual);
        }

        [Fact]
         public void TestGreekPizzaExists()
        {
            // create
            var GreekTest = PizzaFactory.Make<GreekPizza>();
            
            // act
            var Actual = GreekTest;
            
            // assert
            Assert.IsType<GreekPizza>(Actual);
            Assert.NotNull(Actual);
        }

         [Fact]
         public void TestHawaiianPizzaExists()
        {
            // create
            var HawaiianTest = PizzaFactory.Make<HawaiianPizza>();
            
            // act
            var Actual = HawaiianTest;
            
            // assert
            Assert.IsType<HawaiianPizza>(Actual);
            Assert.NotNull(Actual);
        }

        [Fact]
        public void TestCalculateTotalCost()
        {
            //arrange
            var TestPizza = PizzaFactory.Make<MeatPizza>();
            decimal Cost = 0m;
            //act
            Cost = TestPizza.CalculateTotalCost();
            //assert
            Assert.Equal(12.25m, Cost);
        }
        [Fact]
        public void TestCalculateTotalCost3()
        {
            //arrange
            var TestPizza = PizzaFactory.Make<HawaiianPizza>();
            decimal Cost = 0m;
            //act
            Cost = TestPizza.CalculateTotalCost();
            //assert
            Assert.Equal(10m,Cost);
        }
        
    }
} 