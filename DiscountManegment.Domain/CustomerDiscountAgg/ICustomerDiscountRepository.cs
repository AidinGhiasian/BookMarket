using DiscountManegment.Application.Contract.CustomerDiscountApplication;
using Services.Application;

namespace DiscountManegment.Domain.CustomerDiscountAgg
{
    public interface ICustomerDiscountRepository:IRepositoryBase<CustomerDiscount >
    {
        EditCustomerDiscount GetDetaile(long id);
        List<CoustomerDiscountViewModel> Search(CoustomerDiscountSearchModel searchmodel);
    }
}
