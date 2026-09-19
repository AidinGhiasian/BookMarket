using BookM.Infrastructure.EFCore;
using DiscountManegment.Application.Contract.CustomerDiscountApplication;
using DiscountManegment.Domain.CustomerDiscountAgg;
using Services.Application;


namespace DiscountManagement.Infrastructure.EFCore.Repository
{
    public class CustomerDiscountRepository : RepositoryBase<CustomerDiscount>, ICustomerDiscountRepository
    {
        private readonly DiscountContext _discountContext;
        private readonly BookDbContext _shopContext;
        public CustomerDiscountRepository(DiscountContext context, BookDbContext shopContext) : base(context)
        {
            _discountContext = context;
            _shopContext = shopContext;
        }

        public EditCustomerDiscount? GetDetaile(long id)
        {
            return _discountContext.CustomerDiscounts.Select(d => new EditCustomerDiscount()
            {
                DiscountRate = d.DiscountRate,
                EndDate = d.EndDate.ToFarsi(),
                Id = d.Id,
                ProductId = d.ProductId,
                Reason = d.Reason,
                StartDate = d.StartDate.ToFarsi(),
            }).FirstOrDefault(d => d.Id == id);
        }

        public List<CoustomerDiscountViewModel> Search(CoustomerDiscountSearchModel searchmodel)
        {
            var products = _shopContext.Books.Select(p => new { p.Id, p.BookTitle }).ToList();

            var query = _discountContext.CustomerDiscounts.Select(d => new CoustomerDiscountViewModel()
            {
                Id = d.Id,
                ProductId = d.ProductId,
                DiscountRate = d.DiscountRate,
                EndDate = d.EndDate.ToFarsi(),
                StartDate = d.StartDate.ToFarsi(),
                StartDateGr = d.StartDate,
                EndDateGr = d.EndDate,
                Reason = d.Reason,
                CreationDate = d.CreationDateTime.ToFarsi()
            });
            if (searchmodel.ProductId > 0)
            {
                query = query.Where(d => d.ProductId == searchmodel.ProductId);
            }

            if (!string.IsNullOrWhiteSpace(searchmodel.StartDate))
            {

                query = query.Where(d => d.StartDateGr > searchmodel.StartDate.ToGeorgianDateTime());
            }
            if (!string.IsNullOrWhiteSpace(searchmodel.EndDate))
            {
                query = query.Where(d => d.StartDateGr < searchmodel.EndDate.ToGeorgianDateTime());
            }

            var discount = query.OrderByDescending(d => d.Id).ToList();
            
            discount.ForEach(discount =>
                discount.Product = products.FirstOrDefault(p => p.Id == discount.ProductId)?.BookTitle);
                
            return discount;
        }
    }
}
