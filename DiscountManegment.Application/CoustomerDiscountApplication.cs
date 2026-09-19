using DiscountManegment.Application.Contract.CustomerDiscountApplication;
using DiscountManegment.Domain.CustomerDiscountAgg;
using Services.Application;

namespace DiscountManegment.Application
{
    public class CoustomerDiscountApplication : ICustomerDiscountApplication
    {
        private readonly ICustomerDiscountRepository _customerDiscountRepository;

        public CoustomerDiscountApplication(ICustomerDiscountRepository customerDiscountRepository)
        {
            _customerDiscountRepository = customerDiscountRepository;
        }
        public OperationResult Define(DefineCustomerDiscount command)
        {
            var operation = new OperationResult();

            if (_customerDiscountRepository.Exists(x => x.ProductId == command.ProductId&&x.DiscountRate==command.DiscountRate))
                return operation.Failed(ApplicationMessage.Duplicate);

            var startdate = command.StartDate.ToGeorgianDateTime();
            var endDate=command.EndDate.ToGeorgianDateTime();
            var customerdiscount = new CustomerDiscount(command.ProductId, command.DiscountRate, startdate,
                endDate, command.Reason);

            _customerDiscountRepository.Add(customerdiscount);
            _customerDiscountRepository.SaveChanges();

            return operation.IsSuccess();
        }

        public OperationResult Edit(EditCustomerDiscount command)
        {
            var customerdiscount = _customerDiscountRepository.GetByLongId(command.Id);
            var operation = new OperationResult();
            if (customerdiscount == null)
                return operation.Failed(ApplicationMessage.NotFound);

            if (_customerDiscountRepository.Exists(x => x.ProductId == command.ProductId&&x.DiscountRate==command.DiscountRate && x.Id != command.Id))
                return operation.Failed(ApplicationMessage.Duplicate);

            var startdate = command.StartDate.ToGeorgianDateTime();
            var endDate = command.EndDate.ToGeorgianDateTime();

            customerdiscount.Edit(command.ProductId, command.DiscountRate,startdate,
                endDate, command.Reason);
        
            _customerDiscountRepository.SaveChanges();
            return operation.IsSuccess();

        }

        public EditCustomerDiscount GetDetaile(long id)
        {
            return _customerDiscountRepository.GetDetaile(id);

        }

        public List<CoustomerDiscountViewModel> Search(CoustomerDiscountSearchModel searchmodel)
        {
           return _customerDiscountRepository.Search(searchmodel);
        }
    }
}
