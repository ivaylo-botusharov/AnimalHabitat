using System;
using System.Runtime.Serialization;

namespace Ecology.DTO.Exceptions
{
    [Serializable]
    public class DatabaseSeedFailedException : Exception
    {
        public DatabaseSeedFailedException()
        {
        }

        public DatabaseSeedFailedException(string message)
            : base(message)
        {
        }

        public DatabaseSeedFailedException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected DatabaseSeedFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
