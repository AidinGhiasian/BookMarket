using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommentM.Application.Contacts;
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
        public void create(CreateViewModel create)
        {
            var CC = new Comments(create.FullName, create.Message);
            _commentrepository.Create(CC);
        }

        public void Delete(long id)
        {
            _commentrepository.Delete(id);
        }

        public void Edit(EditViewModel edit)
        {
            var EC = _commentrepository.GetById(edit.Id);
            if (EC != null)
            {
                EC.Edit(edit.FullName, edit.Message);
            }
        }

        public Comments GetById(long id)
        {
            var GC = _commentrepository.GetById(id);
            return (GC);
        }

        public List<CommentViewModel> GetComment()
        {
            throw new NotImplementedException();
        }
    }
}
