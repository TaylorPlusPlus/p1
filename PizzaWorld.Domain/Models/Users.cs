using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models
{
    public class User : AEntity
        {
        
        public List<Order> Orders {get; set;}

        public Store SelectedStore{get; set;}

        public string Username {get; set;}

        public User(){

            Orders = new List<Order>();

        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach(var p in Orders.Last().Pizzas)
            {
                sb.AppendLine(p.ToString());
            }
            
            return $"I have selected this shore : {SelectedStore} and you ordered this pizzas: {sb}";
        }

         public double HoursSinceLastOrder()
        {    
          return (DateTime.Now - Orders.Last().PurchaseDate).TotalHours;
        }
        public bool OrderedFromThisStoreWithin24hr()
        {
          foreach(Order order in Orders)
          {
            if(order.Store.EntityId == SelectedStore.EntityId)
            {
              if((DateTime.Now - order.PurchaseDate).TotalHours < 24)
              {
                return true;
              }
            }
          }
          return false;
        }

        public void ListOrderHistory()
        {

          Console.WriteLine("ORDER HISTORY SIZE = " + Orders.Count());
          foreach(Order order in Orders)
            {
              Console.WriteLine(order.ToString());         
            } 
          Console.WriteLine("User Order count = " + Orders.Count());
        }



        }
    }