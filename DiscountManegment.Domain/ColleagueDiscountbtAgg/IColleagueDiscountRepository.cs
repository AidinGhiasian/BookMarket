
using DiscountManegment.Application.Contract.ColleagueDiscountApplication;
using Services.Application;

namespace DiscountManegment.Domain.ColleagueDiscountbtAgg
{
    public interface IColleagueDiscountRepository:IRepositoryBase<Colleague>
    {
      
        EditColleagueDiscount GetDetaile(long id);
        List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchmodel);
    }
}
