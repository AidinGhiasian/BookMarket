using BookM.ClientQueries.Model.Comment;
using CommentM.Application.Contracts;
using Services.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookM.ClientQueries.Queries
{
    public class CommentQueries : ICommentQueries
    {
        private readonly ICommentQueries _commentQueries;
        public CommentQueries(ICommentQueries commentQueries)
        {
         _commentQueries = commentQueries;   
        }

        public OperationResult Delete(int id)
        {
           return _commentQueries.Delete(id);
        }

        public List<Model.Comment.CommentViewModel> GetAll()
        {
          return _commentQueries.GetAll();
        }

        public List<Model.Comment.CommentViewModel> GetComment(int recordId)
        {
          return _commentQueries.GetComment(recordId);
        }
    }
}
