using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models
{
    public class StuffedCrust : ACrustModel
    {
        protected override void AddName()
        {
            Name = "Stuffed";
        }
        protected override void AddPrice()
        {
            Price = 4.00m;
        }
    }
}