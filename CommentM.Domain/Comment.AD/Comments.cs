using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentM.Domain.Comment.AD
{
    public class Comments
    {
        public long Id { get; private set; }
        public string FullName { get; private set; }//کاربر
        public string Message { get; private set; }//کاربر
        public int OwnerId { get; private set; }// پست یا کتابی که قراره براش نظر ثبت بشهID
        public int Type { get; private set; }//تایپ آن چیزی که قراره براش نظر ثبت بشه :Book=>1,Blog=>2,Event=>3
        public DateTime CommentDatetime { get; private set; }
        public bool IsCanceled { get; private set; }//تایید نشدن یک کامنت


        public void Cancel() => IsCanceled = true;//در حالت عادی true باشد

        public Comments() { }

        public Comments(string name, string message,int ownerId)

        {
            FullName = name;
            Message = message;
            OwnerId = ownerId;
            CommentDatetime=DateTime.Now;

        }
        public void ChangeStatus( bool isCanceled)
        {
            IsCanceled = isCanceled;
        }
    }
    
        

}
