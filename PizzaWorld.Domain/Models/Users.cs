using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaWorld.Domain.Models
{
    public class User
        {
        
        public List<Order> Orders {get; set;}

        public Store SelectedStore{get; set;}

        /* each time a user is created, a new list of orders is created.
            Eventually, this list should be gathered
        */
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

        public void PrintAllOrders()
        {
            
        }

        }
    }