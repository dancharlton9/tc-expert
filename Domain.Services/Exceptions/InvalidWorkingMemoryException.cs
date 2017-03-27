using System;

namespace Domain.Services.Exceptions
{
    public class InvalidWorkingMemoryException : Exception
    {
        public InvalidWorkingMemoryException() : base("Working Memory is invalid.")
        {
            
        }

        public InvalidWorkingMemoryException(Exception e) : base("Working Memory is invalid", e)
        {
            
        }
    }
}