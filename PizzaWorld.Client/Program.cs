using System;
using System.Collections.Generic;
using System.Linq;
using PizzaWorld.Domain.Models;
using PizzaWorld.Domain.Singletons;
namespace PizzaWorld.Client
{
    class Program
    {

        //Properties
        private static readonly ClientSingleton _client = ClientSingleton.Instance;
 
        private static readonly SqlClient _sql = new SqlClient();

        public Program()
        {
      
        }
        static void Main(string[] args)
        {

          //Loads the clients store list with stores from the context
            SetSingletonStores();

          //User selects if they are a store or customer
          Console.WriteLine("Are you a store?(Y/N)");
   
          if(Console.ReadLine() == "Y")
          {
            StoreExperience storeExperience = new StoreExperience(_client, _sql);
          }else
          {
            UserExperience userExerience = new UserExperience(_client, _sql);
          }
 
        }
        static void SetSingletonStores()
        {
          foreach(Store store in _sql.ReadStores())
          {
            _client.Stores.Add(store);
          }
        }
    }
}
