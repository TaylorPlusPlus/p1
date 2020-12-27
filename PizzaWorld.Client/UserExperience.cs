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
           //  User.Orders.Add
            //User.Orders = _sql.ReadOrders(User) as List<Order>;

          //todo MAKE FILL ORDER FUNCTION
          //_sql.ReadOrders(User.SelectedStore);
           foreach(Order order in _sql.ReadOrders(User.SelectedStore) )
            {
              //_sql.ReadPizzas(order);
            } 
            
                
           //   foreach(APizzaModel pizza in _sql.ReadPizzas(order))
            //  {
                
               // foreach(AToppingModel topping in _sql.ReadToppings(pizza))
               // {
              //    pizza.Toppings.Add(topping);
              //  }

             //   order.Pizzas.Add(pizza);
           //   }
         //   
         //     order.Pizzas.Add(new HawaiianPizza());
            //  Console.WriteLine("Added order " + order.EntityId);
             // User.Orders.Add(order);
            
            // foreach(APizzaModel pizza in _sql.ReadPizzas(User.Orders))
            //  {
                
               // foreach(AToppingModel topping in _sql.ReadToppings(pizza))
               // {
              //    pizza.Toppings.Add(topping);
              //  }

           //  //   order.Pizzas.Add(pizza);
           //   }


          //TODO MAKE FILL PIZZA FUNCTION


              //add Pizzas to the orders
           

            Console.WriteLine("\nUsername in Userview " + User.Username);
            // list all the stores the user can choose from
            PrintAllStores();
            
            // Seperate this 
            // allows the user to select their current store
            UserSelectStore();
            //CHANGED user.SelectedStore = _client.SelectStore();
      //       ListOrderHistory();
            // Seperate This
            // check if the user has placed an order within the last 24 hours at this selected store
            // check if the user hasn't ordered within 2 hours
            // allows the user to create an order
         //   UserCreateOrder();
            
            //user.SelectedStore.CreateOrder();

            // UserModifyOrder()
            // allows the user to modify their order. Note the order will only be saved to
            // the user 
            //once it is complete
            UserModifyOrder();

            //Adds the order to the users list of orders 
            //TODO add functionality to save the users order
            CompleteOrder();

            ListOrderHistory();

           // Order MostRecentOrder = user.SelectedStore.Orders.Last();

           // user.Orders.Add(MostRecentOrder); 
          //  MostRecentOrder.MakeMeatPizza();

          //  Console.WriteLine(user.ToString());
            
        }

        //TODO this method needs to be broken up
        void UserModifyOrder()
        {
            // Break this into a new method
            //checking an order exists
            if(CurrentOrder == null)
            {
                // checking if user is allowed to make an order
             //  if(UserCreateOrder() == false)
             //  {
             //      return;
            //   }
            //    
                //the user doesn't have an order and is allowed to make one, thus an order is made
               CurrentOrder = new Order();
            }

          Console.WriteLine("Select a Pizza add to your order\n1: Meat pizza\n2: Hawaiian pizza\n3: Greek pizza");
          int.TryParse(Console.ReadLine(), out  int input);

          if(input == 1){

            CurrentOrder.MakeMeatPizza();
            // update and the stores most recent order .
            
          
            // add this functionallity to its only COMPLETEORDER FUNCTION
            //user.Orders.Add(MostRecentOrder); 

              //TODO need to add type checking   
          }
            if(input == 2){
               CurrentOrder.MakeHawaiianPizza();
/*
             CurrentOrder.MakeHawaiianPizza();
            //I really dont like this.
            // Get most recently created order from the store
            Order MostRecentOrder = User.SelectedStore.Orders.Last();
            // add the pizza to the order.
            MostRecentOrder.MakeMeatPizza();
            // update and the stores most recent order .
            User.SelectedStore.Orders.Last().Equals(MostRecentOrder);
          
            // add this functionallity to its only COMPLETEORDER FUNCTION
            //user.Orders.Add(MostRecentOrder); 

              //TODO need to add type checking   
              */
          }
          if(input == 3){

            //I really dont like this.
            // Get most recently created order from the store
            Order MostRecentOrder = User.SelectedStore.Orders.Last();
            // add the pizza to the order.
            MostRecentOrder.MakeMeatPizza();
            // update and the stores most recent order .
            User.SelectedStore.Orders.Last().Equals(MostRecentOrder);
          
            // add this functionallity to its only COMPLETEORDER FUNCTION
            //user.Orders.Add(MostRecentOrder); 

              //TODO need to add type checking   
          }
    
        }

        void ListOrderHistory()
        {
            //IEnumerable<Order> UsersHistory = _sql.ReadOrders(User);

            //Add query for Pizza's with ordernumber

            //Add a query for Toppings with PizzaModelEntityId

            //Build the orders as they come



            Console.WriteLine("ORDER HISTORY SIZE = " + User.Orders.Count());
           // if(UsersHistory == null)
           // {
           //     Console.WriteLine("You do not have an order history");
          //      return;
          //  }else
            {
                foreach(Order order in User.Orders)
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
        void CompleteOrder()
        {

           // User.Orders.Add(CurrentOrder);
            //User.SelectedStore.Orders.Add(CurrentOrder);
        //    Console.WriteLine("Store : " + User.SelectedStore + " User: " + User.Username + " Order: " + CurrentOrder);
            _sql.SaveOrder(User.SelectedStore, User, CurrentOrder);

       

        // update the users orders
        //  User.Orders.Add(CurrentOrder);
        //  User.SelectedStore.Orders.Add(CurrentOrder);
            //TODO the following function
         // user.SaveOrders();
          // resetting the current order
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