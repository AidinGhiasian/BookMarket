namespace CommentM.Domain.Comment.AD
{
    public enum CommentStatus
    {
        Pending = 1,
        Approved = 2,
        Rejected = 3,
    }

    public enum CommentType
    {
        Book = 1,
        Blog = 2,
        Event = 3,
    }

    public class Comments
    {
        public long Id { get; private set; }
        public string FullName { get; private set; }
        public string Message { get; private set; }
        public int OwnerId { get; private set; }
        public int Type { get; private set; }
        public DateTime CommentDatetime { get; private set; }
        public int IsStatus { get; private set; }

        public void Cancel() => IsStatus = (int)CommentStatus.Rejected;
        public void Approve() => IsStatus = (int)CommentStatus.Approved;

        private Comments() { }

        public Comments(string name, string message, int ownerId, int type = (int)CommentType.Book)
        {
            FullName = string.IsNullOrWhiteSpace(name) ? throw new ArgumentNullException(nameof(name)) : name;
            Message = string.IsNullOrWhiteSpace(message) ? throw new ArgumentNullException(nameof(message)) : message;
            OwnerId = ownerId;
            Type = type;
            CommentDatetime = DateTime.Now;
            IsStatus = (int)CommentStatus.Pending;
        }

        public void ChangeStatus(int isStatus) => IsStatus = isStatus;
    }
}
