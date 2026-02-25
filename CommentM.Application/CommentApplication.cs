using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommentM.Application.Contracts;
using CommentM.Domain.Comment.AD;

namespace CommentM.Application
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository _commentrepository;
        public CommentApplication(ICommentRepository commentrepository)
        {
            _commentrepository = commentrepository;
        }
        public void Create(CreateViewModel create)
        {
            var CC = new Comments(create.FullName, create.Message);
            _commentrepository.Add(CC);
            _commentrepository.SaveChanges();
        }

        public void Delete(int id)
        {
            _commentrepository.GetById(id);

        }

        public List<Comments> GetAll()
        {
            var comments = GetAll();
            return comments;
        }

        public List<CommentViewModel> GetComment(int recordId)
        {
            var comments = _commentrepository.GetAll();
            var commentViewModels = new List<CommentViewModel>();
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
                Id =Convert.ToInt32(comments.Id),
                FullName = comments.FullName,
                Message = comments.Message,
                CommentDateTime = comments.CommentDatetime
            };
        }
    }
}
