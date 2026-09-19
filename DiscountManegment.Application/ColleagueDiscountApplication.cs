using DiscountManegment.Application.Contract.ColleagueDiscountApplication;
using DiscountManegment.Domain.ColleagueDiscountbtAgg;
using Services.Application;

namespace DiscountManegment.Application
{
    public class ColleagueDiscountApplication : IColleagueDiscountApplication
    {
        private readonly IColleagueDiscountRepository _colleagueDiscountRepository;

        public ColleagueDiscountApplication(IColleagueDiscountRepository colleagueDiscountRepository)
        {
            _colleagueDiscountRepository = colleagueDiscountRepository;
        }
        public OperationResult Define(DefineColleagueDiscount command)
        {
            var operation = new OperationResult();
            if (_colleagueDiscountRepository.Exists(x => x.PoroductId == command.PoroductId))
                return operation.Failed(ApplicationMessage.Duplicate);
            var colleague = new Colleague(command.PoroductId, command.DiscountRate);
            _colleagueDiscountRepository.Add(colleague);
            _colleagueDiscountRepository.SaveChanges();
            return operation.IsSuccess();

        }

        public OperationResult Edit(EditColleagueDiscount command)
        {
            var colleague = _colleagueDiscountRepository.GetByLongId(command.Id);

            var operation = new OperationResult();

            if (colleague == null)
                return operation.Failed(ApplicationMessage.NotFound);

          
            colleague.Edit(command.PoroductId, command.DiscountRate);

            _colleagueDiscountRepository.SaveChanges();
            return operation.IsSuccess();
        }

        public OperationResult Delete(long id)
        {
            var colleague = _colleagueDiscountRepository.GetByLongId(id);

            var operation = new OperationResult();

            if (colleague == null)
                return operation.Failed(ApplicationMessage.NotFound);

           
            colleague.IsInDelete();

            _colleagueDiscountRepository.SaveChanges();
            return operation.IsSuccess();
        }

        public OperationResult Restore(long id)
        {
            var colleague = _colleagueDiscountRepository.GetByLongId(id);

            var operation = new OperationResult();

            if (colleague == null)
                return operation.Failed(ApplicationMessage.NotFound);


            colleague.Restore();

            _colleagueDiscountRepository.SaveChanges();
            return operation.IsSuccess();
        }

        public EditColleagueDiscount GetDetaile(long id)
        {
            return _colleagueDiscountRepository.GetDetaile(id);
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchmodel)
        {
            return _colleagueDiscountRepository.Search(searchmodel);
        }
    }
}
