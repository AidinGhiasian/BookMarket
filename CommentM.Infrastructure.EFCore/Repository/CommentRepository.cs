using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommentM.Domain.Comment.AD;
using Services;

namespace CommentM.Infrastructure.EFCore.Repository
{
    public class CommentRepository : RepositoryBase<Comments>, ICommentRepository
    {
        private readonly CommentDbContext _commentDbContext;
        public CommentRepository(CommentDbContext commentdbcontext) : base(commentdbcontext)
        {
            _commentDbContext = commentdbcontext;
        }

        public void Create(Comments create)
        {
            _commentDbContext.Add(create);
            _commentDbContext.SaveChanges();
        }

        public void Delete(long id)
        {
            var DC = _commentDbContext.Comments.Find(id);
            if (id != null)
            {
                _commentDbContext.Remove(id);
            }

        }

        public List<Comments> GetAll(string name)
        {
            return _commentDbContext.Comments.Where(x => x.FullName == name).ToList();
        }

        public void UpdateBy(Comments update)
        {
            var EC = _commentDbContext.Comments.FirstOrDefault(x => x.FullName == update.FullName);
            if (EC != null)
            {
                EC.Edit(update.FullName,update.Message);
                _commentDbContext.SaveChanges();
            }
        }
    }
}
