using Services.Application;

namespace DiscountManegment.Application.Contract.ColleagueDiscountApplication
{
    public interface IColleagueDiscountApplication
    {
        OperationResult Define(DefineColleagueDiscount command);
        OperationResult Edit(EditColleagueDiscount command);
        OperationResult Delete(long  id);
        OperationResult Restore(long id);
        EditColleagueDiscount GetDetaile(long id);
        List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchmodel);
    }
}
