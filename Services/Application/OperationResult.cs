namespace Services.Application
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public bool Failure { get; set; }
        public string Message { get; set; } = string.Empty;

        public OperationResult() { Success = false; Failure = false; }

        public OperationResult IsSuccess(string message = "عملیات با موفقیت انجام شد.")
        {
            Success = true;
            Failure = false;
            Message = message;
            return this;
        }

        public OperationResult Failed(string message)
        {
            Failure = true;
            Success = false;
            Message = message;
            return this;
        }
    }
}
