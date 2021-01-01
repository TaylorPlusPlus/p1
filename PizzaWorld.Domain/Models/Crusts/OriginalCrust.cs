using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models
{
    public class OriginalCrust : ACrustModel
    {
        protected override void AddName()
        {
            Name = "Original";
        }
        protected override void AddPrice()
        {
            Price = 2.00m;
        }
    }
}