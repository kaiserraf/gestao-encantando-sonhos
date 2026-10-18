namespace gesApi.src.Utils.Exceptions
{
    public class CpfExistsException : Exception {
        public CpfExistsException() { }

        public CpfExistsException(string message)
            : base(message) { }

        public CpfExistsException(string message, Exception inner)
            : base(message, inner) { }
    }
}