using Services.Domain;


namespace DiscountManegment.Domain.ColleagueDiscountbtAgg
{
    public class Colleague:EntityBase
    {
        public long PoroductId { get; private set; }
        public int DiscountRate { get; private set; }
        public bool IsDeleted { get; private set; }

        public Colleague(long poroductId, int discountRate)
        {
            PoroductId = poroductId;
            DiscountRate = discountRate;
            IsDeleted = false;
        }
        public void Edit(long poroductId, int discountRate)
        {
            PoroductId = poroductId;
            DiscountRate = discountRate;
           
        }

        public void IsInDelete()
        {
            IsDeleted=true;
        }
        public void Restore()
        {
            IsDeleted = false;
        }
    }
}
