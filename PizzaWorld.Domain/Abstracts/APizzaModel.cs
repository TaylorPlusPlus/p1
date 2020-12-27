using System.Collections.Generic;
using System;
using PizzaWorld.Domain.Factories;

namespace PizzaWorld.Domain.Abstracts
{
    public class APizzaModel : AEntity
    {

        // three fields
        public string Crust { get; set;}
        public string Size { get; set;}

        public List<AToppingModel> Toppings {get; set;}

        public GenericToppingFactory topping = new GenericToppingFactory();
        //public List<S> Toppings{get; set;}
        // a constructor that calls the three methods to set the fields
       protected APizzaModel()
        {
            AddCrust();
            AddSize();
            AddToppings();
        }
        // three methods that set the properties uniquely to the implementation
        protected void AddCrust(){
            Crust = "Original";
        }
        protected void AddSize()
        {
          //  Size = "Large";
           //  Console.WriteLine("Choose Size: Small, Medium, Large, XLarge");
            //  string size = Console.ReadLine();
        }
        protected virtual void AddToppings(){}

        public override string ToString()
        {
            string returnString = $"Crust: {Crust} Size: {Size} Toppings: ";
               try{ foreach(AToppingModel topping in Toppings)
                {
                    returnString += "\n\t" + topping.ToString();
                }
               }catch(NullReferenceException e )
                {
                    Console.WriteLine("NULL VALUE");
                    e.ToString();
                }
            return returnString;
        }
         
    }
}