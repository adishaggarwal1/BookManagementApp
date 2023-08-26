using System.Runtime.Serialization;

namespace TeamB.BookManagement
{
    public class InvalidIdException<ID> : Exception
    {
        public InvalidIdException()
        {
        }

        public InvalidIdException(string? message) : base(message)
        {
        }

        public InvalidIdException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidIdException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ID Id { get; set; }
    }
}
