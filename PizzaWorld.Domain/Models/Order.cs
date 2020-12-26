using System;
using System.Collections.Generic;
using PizzaWorld.Domain.Abstracts;
using PizzaWorld.Domain.Factories;

namespace PizzaWorld.Domain.Models
{
    public class Order : AEntity
    {

        private GenericPizzaFactory _pizzaFactory = new GenericPizzaFactory();

       //DELETE FOR DATABASE public List<APizzaModel> Pizzas {get; set;}
       public List<APizzaModel> Pizzas {get; set;}
        public bool completed = false;

        //Pizzas need to be initialized

        public Order()
        {
            Pizzas = new List<APizzaModel>();
            //Pizzas = new List<MeatPizza>();
        }
        

        /*
        public void MakePizza(string pizzaType)
        {
            Type type = Type.GetType(pizzaType);
             //requirement: An order can only have 50 pizza's
            if(Pizzas.Count <= 50)
            {
                
                Pizzas.Add(_pizzaFactory.Make<type>());
            }
        }
            */
        
        public void MakeMeatPizza()
        {
            //requirement: An order can only have 50 pizza's
            if(Pizzas.Count <= 50)
            {
                Pizzas.Add(_pizzaFactory.Make<MeatPizza>());
            }
            
        }
/*
         public void MakeHawaiianPizza()
        {
            //requirement: An order can only have 50 pizza's
            if(Pizzas.Count <= 50)
            {
                Pizzas.Add(_pizzaFactory.Make<HawaiianPizza>());
            }
        }
        
        public void MakeGreekPizza()
        {
             //requirement: An order can only have 50 pizza's
            if(Pizzas.Count <= 50)
            {
                Pizzas.Add(_pizzaFactory.Make<GreekPizza>());
            }
        }

       // public MakeGreekPizza
     */   
    }
}