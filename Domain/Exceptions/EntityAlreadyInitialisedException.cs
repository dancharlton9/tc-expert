using System;

namespace Domain.Exceptions
{
    public class EntityAlreadyInitialisedException : Exception
    {
        public EntityAlreadyInitialisedException() : base("Entity already initialised.")
        {

        }

        public EntityAlreadyInitialisedException(Exception e) : base("Entity already initialised.", e)
        {
            
        }
    }
}