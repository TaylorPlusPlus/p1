using System;
using System.Collections.Generic;
using System.Linq;
using PizzaWorld.Domain.Models;
using PizzaWorld.Domain.Singletons;
namespace PizzaWorld.Client
{
    class Program
    {
        // must exist at compile time
        private static readonly ClientSingleton _client = ClientSingleton.Instance;
     //   private static Store UsersSelectedStore;
        private static readonly SqlClient _sql = new SqlClient();
        // is ready as needed when called
        //private readonly ClientSingleton _client2;
        public Program()
        {
            //we created the .Instance method for singleton creation, if there no instance, one will be created, otherwise no
          //  _client2 = ClientSingleton.Instance;
        }
        static void Main(string[] args)
        {
            // var p = new Program();

            //_client.MakeAStore();

            //Loads the clients store list with stores from the context
            SetSingletonStores();
            UserExperience userExerience = new UserExperience(_client, _sql);

          //p._client2.MakeAStore();
         // PrintAllStores();
        //    Console.WriteLine(_client.SelectStore());
     //   UserView();
        }

      //  static IEnumerable<Store> GetStores()
      ////  {
      //       return _client.GetAllStores();
       
      //  }

        static void SetSingletonStores()
        {
          foreach(Store store in _sql.ReadStores())
          {
            _client.Stores.Add(store);
          }
        }



        /*
        static void PrintAllStores()
        {
            foreach(var store in _client.Stores)
            {
                System.Console.WriteLine(store.Name);
            }
        }

        static void UserView()
        {
            // Get the users order history
            var user = new User();


            // list all the stores the user can choose from
            PrintAllStores();
            
            
            // Seperate this 
            // allows the user to select their current store
            UserSelectStore(user);
            //CHANGED user.SelectedStore = _client.SelectStore();

            // Seperate This
            // check if the user has placed an order within the last 24 hours at this selected store
            // check if the user hasn't ordered within 2 hours
            // allows the user to create an order
            UserCreateOrder(user);
            
            //user.SelectedStore.CreateOrder();

            // UserModifyOrder()
            // allows the user to modify their order. Note the order will only be saved to
            // the user 
            //once it is complete
            UserModifyOrder(user);

            //Adds the order to the users list of orders 
            //TODO add functionality to save the users order
            CompleteOrder(user);

           // Order MostRecentOrder = user.SelectedStore.Orders.Last();

           // user.Orders.Add(MostRecentOrder); 
          //  MostRecentOrder.MakeMeatPizza();

            Console.WriteLine(user.ToString());
            
        }
        static void UserModifyOrder(User user)
        {
          Console.WriteLine("Select a Pizza add to your order\n1: Meat pizza\n2: Hawaiian pizza\n3: Greek pizza");
          int.TryParse(Console.ReadLine(), out  int input);

          if(input == 1){

            //I really dont like this.
            // Get most recently created order from the store
            Order MostRecentOrder = user.SelectedStore.Orders.Last();
            // add the pizza to the order.
            MostRecentOrder.MakeMeatPizza();
            // update and the stores most recent order .
            user.SelectedStore.Orders.Last().Equals(MostRecentOrder);
          
            // add this functionallity to its only COMPLETEORDER FUNCTION
            //user.Orders.Add(MostRecentOrder); 

              //TODO need to add type checking   
          }
            if(input == 2){

            //I really dont like this.
            // Get most recently created order from the store
            Order MostRecentOrder = user.SelectedStore.Orders.Last();
            // add the pizza to the order.
            MostRecentOrder.MakeMeatPizza();
            // update and the stores most recent order .
            user.SelectedStore.Orders.Last().Equals(MostRecentOrder);
          
            // add this functionallity to its only COMPLETEORDER FUNCTION
            //user.Orders.Add(MostRecentOrder); 

              //TODO need to add type checking   
          }
          if(input == 33){

            //I really dont like this.
            // Get most recently created order from the store
            Order MostRecentOrder = user.SelectedStore.Orders.Last();
            // add the pizza to the order.
            MostRecentOrder.MakeMeatPizza();
            // update and the stores most recent order .
            user.SelectedStore.Orders.Last().Equals(MostRecentOrder);
          
            // add this functionallity to its only COMPLETEORDER FUNCTION
            //user.Orders.Add(MostRecentOrder); 

              //TODO need to add type checking   
          }
          
          
          
        }
        static void CompleteOrder(User user)
        {
          user.Orders.Add(user.SelectedStore.Orders.Last());
            //TODO the following function
         // user.SaveOrders();
        }

        static void UserSelectStore(User user)
        {
          user.SelectedStore = _client.SelectStore();

          Console.WriteLine($"Your current Store is {user.SelectedStore}");
        }
        static void UserCreateOrder(User user)
        {

        double TimeSinceOrder = HoursSinceLastOrder();
          double TimeSinceOrderCurrentStore = HoursSinceLastOrderCurrentLocation();
          //Check if the user placed in order within the last 2 hours
          //Check if the user placed an order with this store within the last 24 hours
          if(TimeSinceOrder > 2 && TimeSinceOrderCurrentStore > 24){
            user.SelectedStore.CreateOrder();
          }else{
            //Inform User why 
            if(TimeSinceOrder < 2 )
            {
              Console.WriteLine("You have placed an order within the last 2 hours");
            }else
            {
              Console.WriteLine("You have placed an order at this location within the last 24 hours");
            }
            
          }
          
        }

        //checks when the last order was made, returns minutes
        static double HoursSinceLastOrder()
        {
          //TODO check from database or file when this user created their last order
          double HoursSinceLastOrder = 3;
          return HoursSinceLastOrder;
        }
        static double HoursSinceLastOrderCurrentLocation()
        {
          //TODO check from database or file when this user created their last order at this location
          double HoursSinceLastOrderCurrentLocation = 25;
          return HoursSinceLastOrderCurrentLocation;
        }


        static void StoreView()
        {

        }


          /*     static void PrintAllStoresEF()
        {
            foreach(var store in _sql.ReadStores())
            {
                System.Console.WriteLine(store);
            }
        }
        */
    }
}
