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
            // Get the users order history
            //User = new User();
        
            PrintAllStores();
            UserSelectStore();

            bool StillInSwitch = true;
            int UserInput;
            // list all the stores the user can choose from and allows user to choose a store
            

            while(StillInSwitch)
            {
              Console.WriteLine("1.View All Order History\n" +
                                "2.View Order History by customer\n" +
                                "3.Sales history under construction\n4.Exit");
              UserInput = int.Parse(Console.ReadLine());
              switch(UserInput)
              {
                case 1:

                  break;
                case 2:
                 
                  break;
                case 3:
                  
                  break;
                case 4:
                  StillInSwitch = false;
                  break;
              }
            }
        }

      
        void ListOrderHistory()
        {
             foreach(Order order in _sql.ReadOrders(Store) )
            {

            } 

            Console.WriteLine("ORDER HISTORY SIZE = " + Store.Orders.Count());

            {
                foreach(Order order in Store.Orders)
                {
                   foreach(APizzaModel pizza in _sql.ReadPizzas(order))
                   {

                     foreach(AToppingModel topping in _sql.ReadToppings(pizza))
                    { 
                      
                    }
                      
                     foreach(ACrustModel crust in _sql.ReadCrust(pizza))
                     {

                     }
                   }    
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