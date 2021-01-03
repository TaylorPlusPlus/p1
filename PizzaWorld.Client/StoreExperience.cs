using PizzaWorld.Domain.Abstracts;
using PizzaWorld.Domain.Models;
using PizzaWorld.Domain.Singletons;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaWorld.Client
{
    public class StoreExperience
    {
        public readonly ClientSingleton _client;
        public readonly SqlClient _sql;
        private Store Store;
        public StoreExperience(ClientSingleton _client, SqlClient _sql)
        {
            this._sql = _sql;
            this._client = _client;
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
            PrintAllStores();
            UserSelectStore();

            Store = _sql.StoreOrderHistory(Store);

            bool StillInSwitch = true;
            int UserInput;
     
            while(StillInSwitch)
            {
              Console.WriteLine("1: View history\n" +
                                "2: View Sales\n3: Exit");
              UserInput = int.Parse(Console.ReadLine());
              switch(UserInput)
              {
                case 1:
                  OrderHistoryLoop();
                  break;
                case 2:
                  SalesLoop();
                  break;
                case 3:
                  StillInSwitch = false;
                  break;
              }
            }
        }

        public void SalesLoop()
        {
                                //[count][revatue]
          decimal[] GreekPizza = {0, 0};
          decimal[] HawaiianPizza = {0, 0};
          decimal[] MeatPizza = {0, 0};
          foreach(Order order in Store.Orders)
          {
            if(CheckIfOrderPlacedWithinWeek(order))
            {
              foreach(APizzaModel pizza in order.Pizzas)
              {
                foreach(AToppingModel topping in pizza.Toppings)
                {
                  if(topping.Name == "Pineapple")
                  {
                    HawaiianPizza[0] = HawaiianPizza[0] + 1;
                    HawaiianPizza[1] = HawaiianPizza[1] + pizza.CalculateTotalCost();
                  }
                  if(topping.Name == "Feta")
                  {
                    GreekPizza[0] = GreekPizza[0] + 1;
                    GreekPizza[1] = GreekPizza[1] + pizza.CalculateTotalCost();
                  }
                  if(topping.Name == "Sausage")
                  {
                    MeatPizza[0] = MeatPizza[0] + 1;
                    MeatPizza[1] = MeatPizza[1] + pizza.CalculateTotalCost();
                  }
                }
              }
            }
          }
          Console.WriteLine("For this week, the number of pizza's sold and revenue for each pizza type is as follows:\n" +
                            "Greek Pizza: \n\tsale count: " + GreekPizza[0] + "\n\trevenue: " + GreekPizza[1] +
                            "\nHawaiian Pizza: \n\tsale count: " + HawaiianPizza[0] + "\n\trevenue: " + HawaiianPizza[1] +
                            "\nMeat Pizza: \n\tsale count: " + MeatPizza[0] + "\n\trevenue: " + MeatPizza[1] + "\n");
        }

        public bool CheckIfOrderPlacedWithinWeek(Order order)
        {
          if((DateTime.Now - order.PurchaseDate).TotalDays < 7)
          {
            return true;
          }
          return false;
        }


        public void OrderHistoryLoop()
        {
          bool ViewingOrderHistory = true;
          int UserInput;

          while(ViewingOrderHistory)
          {
            Console.WriteLine("1: All Order History\n2: Order history by customer\n3: go back");
            UserInput = int.Parse(Console.ReadLine());

            switch(UserInput)
            {
              case 1:
                ListOrderHistory();
                break;
              case 2:
                ListOrderHistoryByUsername();
                break;
              case 3:
                ViewingOrderHistory = false;
                break;
            }
          }
        }
      
        void ListOrderHistory()
        {  
          Console.WriteLine("ORDER HISTORY SIZE = " + Store.Orders.Count());
          foreach(Order order in Store.Orders)
            {
              Console.WriteLine(order.ToString());  
        //      Console.WriteLine("This ORDERS USERS ID = " + order.User.EntityId + "\n\n");
        //      Console.WriteLine("This ORDERS Username = " + order.User.Username + "\n\n");     
            }      
        }

        void ListOrderHistoryByUsername()
        {
          string customerName = "";

          Console.WriteLine("What is the Username of the Customer you would like to search by: ");
          customerName = Console.ReadLine();

          foreach(Order order in Store.Orders)
          {
            if(order.User.Username == customerName)
            {
              Console.WriteLine(order.ToString());
            }
          }
        }
       

        void UserSelectStore()
        {
          Store = _client.SelectStore();

          Console.WriteLine($"Hello store {Store.Name}");
        }
    }
}