using Services.Application;

namespace DiscountManegment.Application.Contract.CustomerDiscountApplication
{
    public interface ICustomerDiscountApplication
    {
        OperationResult Define(DefineCustomerDiscount command);
        OperationResult Edit(EditCustomerDiscount command);

        EditCustomerDiscount GetDetaile(long id);
        List<CoustomerDiscountViewModel> Search(CoustomerDiscountSearchModel searchmodel);
    }
}
