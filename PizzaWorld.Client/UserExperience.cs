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
          User = _sql.ReadOneUser("First");
          UpdateMainUSer();
          bool StillInSwitch = true;
          int UserInput;

          // list all the stores the user can choose from and allows user to choose a store
          PrintAllStores();
          UserSelectStore();

          while(StillInSwitch)
            {
              Console.WriteLine("1.Create and modify an order\n" +
                                "2.View Order History\n"+
                                "3.Select a new Store\n4.Exit");
              UserInput = int.Parse(Console.ReadLine());
              switch(UserInput)
              {
                case 1:
                UserModifyOrder();
                break;
                case 2:
                  User.ListOrderHistory();
                  break;
                case 3:
                  PrintAllStores();
                  UserSelectStore();
                  break;
                case 4:
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
          bool InOrderSwitch = true;
          int UserOrderInput = 0;

          if(!CreateNewOrder())
          {
            Console.WriteLine("\nCouldn't Create Order\n");
            InOrderSwitch = false;
          }

          while(InOrderSwitch){

              //Displaying menu + getting input
              Console.WriteLine("\n\t1: Add pizza to your order" + 
                                "\n\t2: Remove pizza from your order" +
                                "\n\t3: View current order" +
                                "\n\t4: Check out" +
                                "\n\t5: Cancel order");
              UserOrderInput = int.Parse(Console.ReadLine());
              
              switch(UserOrderInput)
              {
                case 1:
                  AddPizzaToOrder();
                  break;
                case 2:
                  RemovePizzaFromOrder();
                  break;
                case 3:
                  ViewCurrentOrder();
                  break;
                case 4:
                  CompleteOrder();
                  InOrderSwitch = false;
                  break;
                case 5:
                  InOrderSwitch = false;
                  break;

              }
          }
       
        }

        void AddPizzaToOrder()
        {
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

          //TODO And input validation
          //This Lets the user make whatever type of pizza they just ordered a large
          CurrentOrder.Pizzas.Last().MakeLarge();
        }

        void RemovePizzaFromOrder()
        {
          
          string UsersOptions = "";
          int PizzaIndex = 0;

          if(CurrentOrder != null)
          {
            if(CurrentOrder.Pizzas.Count() == 0)
            {
              Console.WriteLine("---------------------------------------\n" +
                                "You do not have any pizza in your order\n" +
                                "---------------------------------------");
              return;
            }
            UsersOptions += "---------------------------------\n";
            for(int i = 1; i <= CurrentOrder.Pizzas.Count(); i ++)
            {
              UsersOptions += "\n" + i +". \n" + CurrentOrder.Pizzas.ElementAt(i - 1).ToString();
            }
            UsersOptions += "\nWhich pizza would you like to remove?\n";
            UsersOptions += "-------------------------------------";
            Console.WriteLine(UsersOptions);
            PizzaIndex = int.Parse(Console.ReadLine());

            CurrentOrder.Pizzas.RemoveAt(PizzaIndex - 1);

          }
        }

        public void ViewCurrentOrder()
        {
          Console.WriteLine(CurrentOrder.ToString());
        }
        public void CompleteOrder()
        {
          CurrentOrder.PurchaseDate = DateTime.Now;
         _sql.SaveOrder(User.SelectedStore, User, CurrentOrder);
   //      User.Orders.Add(CurrentOrder);
         CurrentOrder = null;
         
        }

        public void UserSelectStore()
        {
          User.SelectedStore = _client.SelectStore();

          Console.WriteLine($"Your current Store is {User.SelectedStore}");
        }
  
        public bool CreateNewOrder()
        {
          if(User.HoursSinceLastOrder() < 2)
          {
             Console.WriteLine("You have placed an order within the last 2 hours");
             return false;
          }
          if(User.OrderedFromThisStoreWithin24hr())
          {
            Console.WriteLine("You have placed an order at this location within the last 24 hours");
            return false;
          }
          CurrentOrder = new Order();
          CurrentOrder.User = User;
          CurrentOrder.Store = User.SelectedStore;
          return true;
        }
    }
}