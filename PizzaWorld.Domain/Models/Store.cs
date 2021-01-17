using System.Collections.Generic;
using System;
using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models
{
    public class Store : AEntity
    {
        public List<Order> Orders {get; set;}
        public string Name {get; set;}

     //   public int StoreId{get; set;}
        
        public Store()
        {
            Orders = new List<Order>();
        }

        public bool CheckIfOrderPlacedWithinWeek(Order order)
        {
          if((DateTime.Now - order.PurchaseDate).TotalDays < 7)
          {
            return true;
          }
          return false;
        }
         public string ListOrderHistory()
        {  
          string returnString = "";
          foreach(Order order in Orders)
            {
              returnString += order.ToString();   
            }   
            return returnString;   
        }

        public string ListOrderHistoryByUsername(string customerName)
        {
          string returnString = "";
          foreach(Order order in Orders)
          {
            if(order.User.Username.ToLower() == customerName.ToLower())
            {
              returnString += order.ToString();
            }
          }
          return returnString;
        }

        public string SalesLoop()
        {
                                //[count][revatue]
          string returnString = "";
          decimal[] GreekPizza = {0, 0};
          decimal[] HawaiianPizza = {0, 0};
          decimal[] MeatPizza = {0, 0};
          foreach(Order order in Orders)
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
          returnString += "For this week, the number of pizza's sold and revenue for each pizza type is as follows:\n" +
                            "Greek Pizza: \n\tsale count: " + GreekPizza[0] + "\n\trevenue: " + GreekPizza[1] +
                            "\nHawaiian Pizza: \n\tsale count: " + HawaiianPizza[0] + "\n\trevenue: " + HawaiianPizza[1] +
                            "\nMeat Pizza: \n\tsale count: " + MeatPizza[0] + "\n\trevenue: " + MeatPizza[1] + "\n";
        return returnString;
        }
    }
}