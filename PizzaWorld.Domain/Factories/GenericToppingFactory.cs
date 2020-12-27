using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Factories
{

    public class GenericToppingFactory
    {
        //going to use generics, need to study the actual code
        public T Make<T>() where T : AToppingModel, new ()
        {
            return new T();
        }
    }
}