using System.Collections.Generic;
using System;
using PizzaWorld.Domain.Factories;

namespace PizzaWorld.Domain.Abstracts
{
    public class APizzaModel : AEntity
    {
        public ACrustModel Crust { get; set;}
        public string Size { get; set;}

        public List<AToppingModel> Toppings {get; set;}
        public GenericToppingFactory topping = new GenericToppingFactory();
        public GenericCrustFactory crust = new GenericCrustFactory();

       protected APizzaModel()
        {
            AddCrust();
            AddSize();
            AddToppings();
        }

        protected virtual void AddCrust(){}
        protected virtual void AddSize()
        {
  
           Size = "Small";
        }

        public void MakeLarge()
        {
         //   Console.WriteLine("Would you like to make this a Large Pizza? (Y/N)");
            
         //   if(Console.ReadLine() == "Y")
        //    {
         //       Size = "Large";
         //   }
        }
        protected virtual void AddToppings(){}


         public virtual decimal CalculateTotalCost()
        {
            decimal totalCost = 0;

            try{
                foreach(AToppingModel top in Toppings)
                {
                    totalCost += top.Price;
                }

                switch(Size)
                {
                    case "Small":
                        totalCost += 5m;
                        break;
                    case "Large":
                        totalCost += 7m;
                        break;
                }
                totalCost += Crust.Price;

            }catch(NullReferenceException)
            {
                totalCost = 0.00m;
            }

            return totalCost;
        }

        public override string ToString()
        {
            string returnString = "";
            try{

                returnString = $"Crust: {Crust}\n" + 
                                  $"Size: {Size} Toppings: ";

                foreach(AToppingModel topping in Toppings)
                {
                    returnString += "\n\t" + topping.ToString();
                }
               }catch(NullReferenceException e )
                {
                    Console.WriteLine("NULL VALUE");
                    e.ToString();
                }
                
                returnString += "\nPizza Cost: " + CalculateTotalCost() + "\n";
            return returnString;
        }
        
    }
}