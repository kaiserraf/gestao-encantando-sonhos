namespace gesApi.src.Utils.Exceptions
{
    public class IncorrectException : Exception {
        public IncorrectException() { }

        public IncorrectException(string message)
            : base(message) { }

        public IncorrectException(string message, Exception inner)
            : base(message, inner) { }
    }
}