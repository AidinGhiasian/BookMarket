using BookM.Infrastructure.EFCore;
using DiscountManegment.Application.Contract.ColleagueDiscountApplication;
using DiscountManegment.Domain.ColleagueDiscountbtAgg;
using Services.Application;

namespace DiscountManagement.Infrastructure.EFCore.Repository
{
    public class ColleagueDiscountRepository:RepositoryBase<Colleague>,IColleagueDiscountRepository
    {
        private readonly DiscountContext _discountContext;
        private readonly BookDbContext _shopContext;

        public ColleagueDiscountRepository(DiscountContext discountcontext, BookDbContext shopContext) : base(discountcontext)
        {
            _discountContext = discountcontext;
            _shopContext = shopContext;
        }

     

        public EditColleagueDiscount? GetDetaile(long id)
        {
            return _discountContext.Colleagues.Select(c => new EditColleagueDiscount()
            {
                Id = c.Id,
              DiscountRate = c.DiscountRate,
              PoroductId = c.PoroductId,
              
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchmodel)
        {
            var products = _shopContext.Books.Select(p => new { p.Id, p.BookTitle }).ToList();
            var query = _discountContext.Colleagues.Select(x => new ColleagueDiscountViewModel()
            {
                Id=x.Id,
                DiscountRate = x.DiscountRate,
                PoroductId = x.PoroductId,
                CreateDateTime = x.CreationDateTime.ToFarsi(),
                Isdeleted = x.IsDeleted
                 
            });
            if (searchmodel.PoroductId > 0)
                query = query.Where(x => x.PoroductId == searchmodel.PoroductId);
            var discount = query.OrderByDescending(x => x.Id).ToList();
            discount.ForEach(discount =>
                discount.product = products.FirstOrDefault(p => p.Id == discount.PoroductId)?.BookTitle);
            return discount;

        }
    }
}
