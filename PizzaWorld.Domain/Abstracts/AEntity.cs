namespace PizzaWorld.Domain.Abstracts
{
    public abstract class AEntity
    {
        public long EntityId{get; set;}


        protected AEntity()
        { 
        //    EntityId = System.DateTime.Now.Ticks;
        }
    }
}