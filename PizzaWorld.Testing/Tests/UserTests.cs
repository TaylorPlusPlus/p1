using Xunit;
using PizzaWorld.Domain.Models;
using System.Collections.Generic;
using System;

namespace PizzaWorld.Testing
{
    public class UserTests
    {
        [Fact]
        private void TestUserExists()
        {
            //create
            var user = new User();
            //act
            var testUser = user;
            //assert
            Assert.IsType<User>(testUser);
            Assert.NotNull(testUser);
        }
        [Fact]
        private void TestHoursSinceLastOrderMoreThan()
        {
            //arrange
            User TestUser = new User();
            Order TestOrder = new Order();
            DateTime TestTime = new DateTime(2000,1,1,8,8,8);
            
            //act
            TestOrder.PurchaseDate = TestTime;
            TestUser.Orders.Add(TestOrder);
            //assert
            Assert.NotInRange(TestUser.HoursSinceLastOrder(),0 , 2);   
        }
        [Fact]
        private void TestHoursSinceLastOrderLessThan()
        {
                //arrange
            User TestUser = new User();
            Order TestOrder = new Order();
            DateTime TestTime = DateTime.Now;
            
            //act
            TestOrder.PurchaseDate = TestTime;
            TestUser.Orders.Add(TestOrder);

            //assert
            Assert.InRange(TestUser.HoursSinceLastOrder(),0 , 2);   

        }

        // TWO NEW TESTS FOR ORDERSFROMSTORE24hr

    }

}