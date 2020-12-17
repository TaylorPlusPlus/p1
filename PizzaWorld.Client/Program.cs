using System;
using System.Collections.Generic;
using PizzaWorld.Domain.Models;

namespace PizzaWorld.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintAllStores();
        }

        static IEnumerable<Store> GetStores()
        {
             return new List<Store>(){
                 new Store(),
                 new Store(),
                 new Store()
             };
       
        }

        static void PrintAllStores()
        {
            foreach(var store in GetStores())
            {
                System.Console.WriteLine(store);
            }
        }
    }
}
