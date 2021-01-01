using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Factories
{

    public class GenericCrustFactory
    {
        //going to use generics, need to study the actual code
        public T Make<T>() where T : ACrustModel, new ()
        {
            return new T();
        }
    }
}