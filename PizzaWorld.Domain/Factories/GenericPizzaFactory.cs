using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Factories
{

    public class GenericPizzaFactory
    {
        //going to use generics, need to study the actual code
        public T Make<T>() where T : APizzaModel, new ()
        {
            return new T();
        }
    }
}