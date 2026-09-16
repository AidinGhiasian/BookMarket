namespace BookM.Application.Contracts.Order
{
    public class CartItem
    {
        public long Id { get; set; }
        public string PictureFile { get; set; }
        public string BookTitle { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public double TotalPrice { get; set; }
        public CartItem()
        {
            TotalPrice = Price * Count;
        }

    }
}
