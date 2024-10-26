namespace ReactBank.Domain.Core.Notifications
{
    public class Result<T>
    {
        public bool IsSuccess { get; private set; }
        public bool IsNotFound { get; private set; }
        public T Value { get; private set; }
        public Dictionary<string, string> Errors { get; private set; }

        private Result() { }

        public static Result<T> Success(T value) => new Result<T>() { IsSuccess = true, Value = value };

        //TODO: create an easier way to handle errors
        public static Result<T> Failure(Dictionary<string, string> errors) => new() { IsSuccess = false, Errors = errors };
        public static Result<T> NotFound(Dictionary<string, string> errors) => new() { IsSuccess = false, IsNotFound = true, Errors = errors };
    }
}
