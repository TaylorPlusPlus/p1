using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models
{
    public class Sausage : AToppingModel
    {
        protected override void AddName()
        {
            Name = "Sausage";
        }
        protected override void AddPrice()
        {
            Price = "1.50";
        }
    }
}
