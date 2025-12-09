using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentM.Domain.Comment.AD
{
    public interface ICommentRepository
    {
        public void Create(Comments create);
        public List<Comments> GetAll(long recordId);
        public Comments GetById(long id);
        public void UpdateBy(Comments update);
        void Delete(long id);
    }
}
