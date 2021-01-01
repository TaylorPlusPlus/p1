using PizzaWorld.Domain.Abstracts;
using PizzaWorld.Domain.Models;
using PizzaWorld.Domain.Singletons;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaWorld.Client
{
    public class UserExperience
    {
        public readonly ClientSingleton _client;
        public readonly SqlClient _sql;
        private Order CurrentOrder;
        private User User;

        public UserExperience(ClientSingleton _client, SqlClient _sql)
        {
            this._sql = _sql;
            this._client = _client;
            //User = new User();
            UserView();
            
        }

        
        void PrintAllStores()
        {
            foreach(var store in _client.Stores)
            {
                System.Console.WriteLine(store.Name);
            }
        }

         void UserView()
        {
            // Get the users order history
            //User = new User();
          
             User = _sql.ReadOneUser("First");
             UpdateMainUSer();
              bool StillInSwitch = true;
              int UserInput;
            // list all the stores the user can choose from and allows user to choose a store
            PrintAllStores();
            UserSelectStore();

            while(StillInSwitch)
            {
              Console.WriteLine("1.Create or Modify an Order\n" +
                                "2.Check out\n3.View Order History\n"+
                                "4.Select a new Store\n5.Exit");
              UserInput = int.Parse(Console.ReadLine());
              switch(UserInput)
              {
                case 1:
                UserModifyOrder();
                break;
                case 2:
                  if(CurrentOrder == null)
                  {
                    Console.WriteLine("You must first create an order before you can check out");
                  }else
                  {
                  CompleteOrder();
                  }
                  break;
                case 3:
                  ListOrderHistory();
                  break;
                case 4:
                  PrintAllStores();
                  UserSelectStore();
                  break;
                case 5:
                  StillInSwitch = false;
                  break;
              }
            } 
        }

        public void UpdateMainUSer()
        {
          User = _sql.UserOrderHistory(User);
        }

        //TODO this method needs to be broken up
        void UserModifyOrder()
        {
            //checking an order exists
            if(CurrentOrder == null)
            {
              /*
              TODO finish the create order function that adds checking features that restrict
              order creation
              */
               CurrentOrder = new Order();
            }

          Console.WriteLine("Select a Pizza add to your order\n1: Meat pizza\n2: Hawaiian pizza\n3: Greek pizza");
          int.TryParse(Console.ReadLine(), out  int input);

          if(input == 1){

            CurrentOrder.MakeMeatPizza(); 
          }
            if(input == 2)
            {
               CurrentOrder.MakeHawaiianPizza();
            }
          if(input == 3){
            CurrentOrder.MakeGreekPizza();
          }
    
        }

        void ListOrderHistory()
        {
        
           /*  foreach(Order order in _sql.ReadOrders(User) )
            {
             
            }*/ 
            Console.WriteLine("ORDER HISTORY SIZE = " + User.Orders.Count());
            
             //User UserTest = _sql.UserOrderHistory(User);
                //foreach(Order order in User.Orders)
                foreach(Order order in User.Orders)
                {
                    Console.WriteLine(order.ToString());         
                } 
                  Console.WriteLine("User Order count = " + User.Orders.Count());
        }
        void CompleteOrder()
        {
         _sql.SaveOrder(User.SelectedStore, User, CurrentOrder);
   //      User.Orders.Add(CurrentOrder);
         CurrentOrder = null;
         
        }

        void UserSelectStore()
        {
          User.SelectedStore = _client.SelectStore();

          Console.WriteLine($"Your current Store is {User.SelectedStore}");
        }
        bool UserCreateOrder()
        {
            
        double TimeSinceOrder = HoursSinceLastOrder();
          double TimeSinceOrderCurrentStore = HoursSinceLastOrderCurrentLocation();
          //Check if the user placed in order within the last 2 hours
          //Check if the user placed an order with this store within the last 24 hours
          if(TimeSinceOrder > 2 && TimeSinceOrderCurrentStore > 24){
            User.SelectedStore.CreateOrder();
            return true;
          }else{
            //Inform User why 
            if(TimeSinceOrder < 2 )
            {
              Console.WriteLine("You have placed an order within the last 2 hours");
            }else
            {
              Console.WriteLine("You have placed an order at this location within the last 24 hours");
            }
            return false;
            
          }
          
        }

        //checks when the last order was made, returns minutes
        double HoursSinceLastOrder()
        {
          //TODO check from database or file when this user created their last order
          double HoursSinceLastOrder = 3;
          return HoursSinceLastOrder;
        }
        double HoursSinceLastOrderCurrentLocation()
        {
          //TODO check from database or file when this user created their last order at this location
          double HoursSinceLastOrderCurrentLocation = 25;
          return HoursSinceLastOrderCurrentLocation;
        }


    }
}