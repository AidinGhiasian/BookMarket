namespace Services.Domain
{
    public class EntityBase
    {
        public long Id { get; set; }
        public DateTime CreationDateTime { get; set; }

        public EntityBase()
        {
            CreationDateTime=DateTime.Now;
        }
    }
}
