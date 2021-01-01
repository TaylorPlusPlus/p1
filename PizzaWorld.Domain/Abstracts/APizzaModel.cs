using System.Collections.Generic;
using System;
using PizzaWorld.Domain.Factories;

namespace PizzaWorld.Domain.Abstracts
{
    public class APizzaModel : AEntity
    {

        // three fields
        public ACrustModel Crust { get; set;}
        public string Size { get; set;}

        public List<AToppingModel> Toppings {get; set;}

        public decimal totalCost {get; set;}
        public GenericToppingFactory topping = new GenericToppingFactory();
        public GenericCrustFactory crust = new GenericCrustFactory();
        //public List<S> Toppings{get; set;}
        // a constructor that calls the three methods to set the fields
       protected APizzaModel()
        {
            AddCrust();
            AddSize();
            AddToppings();
        }
        // three methods that set the properties uniquely to the implementation
        protected virtual void AddCrust(){
        
        }
        protected virtual void AddSize()
        {
            Console.WriteLine("Would you like to make this a Large Pizza? (Y/N)");
            
            if(Console.ReadLine() == "Y")
            {
                Size = "Large";
            }else
            {
                          
            Size = "Small";
            }
  
           
        }
        protected virtual void AddToppings(){}

        protected virtual void CalculateTotalCost()
        {
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
                CalculateTotalCost();
                returnString += "\nPizza Cost: " + totalCost;
            return returnString;
        }
         
    }
}