namespace gesApi.src.Utils.Exceptions
{
    public class RefreshTokenNotFindException : Exception {
        public RefreshTokenNotFindException() { }

        public RefreshTokenNotFindException(string message)
            : base(message) { }

        public RefreshTokenNotFindException(string message, Exception inner)
            : base(message, inner) { }
    }
}