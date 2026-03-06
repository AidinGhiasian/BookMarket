using CommentM.Application.Contracts;
using CommentM.Domain.Comment.AD;
using Services.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentM.Application
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository _commentrepository;
        public CommentApplication(ICommentRepository commentrepository)
        {
            _commentrepository = commentrepository;
        }

        public List<CommentViewModel> CommentStatus(bool status)
        {
          return  _commentrepository.CommentStatus(status).Select(Map).ToList();
        }

        public OperationResult Create(CreateViewModel create)
        {
            var result= new OperationResult();
            var CC = new Comments(create.FullName, create.Message,create.OwnerId);
            _commentrepository.Add(CC);
            _commentrepository.SaveChanges();
            return result.IsSuccess();
        }

        public OperationResult Delete(long id)
        {
            var result = new OperationResult();
            var comment=  _commentrepository.GetById(id);
            if(comment==null)
            {
                return result.Failed("Not Found...");
            }
            _commentrepository.Delete(id);
            return result.IsSuccess();
        }

        public List<CommentViewModel> GetAll()
        {
            return _commentrepository.GetAll().Select(Map).ToList();
        }

        public List<CommentViewModel> GetComment(int ownerId)
        {
            
            var commentViewModels = new List<CommentViewModel>();
            var comments = _commentrepository.GetComment(ownerId);
            foreach (var comment in comments)
            {
                commentViewModels.Add(Map(comment));
            }
            return commentViewModels;
        }


        public CommentViewModel Map(Comments comments)
        {
            return new CommentViewModel
            {
                Id =comments.Id,
                FullName = comments.FullName,
                Message = comments.Message,
                CommentDateTime = comments.CommentDatetime,
                OwnerId = comments.OwnerId,
            };
        }

    }
}
