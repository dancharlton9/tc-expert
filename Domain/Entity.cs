using System;
using Domain.Exceptions;
using Domain.Interfaces;

namespace Domain
{
    public class Entity : IEntity
    {
        public Entity(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }

        public void InitialiseIdentity(Guid id)
        {
            if (!Id.Equals(Guid.Empty))
            {
                throw new EntityAlreadyInitialisedException();
            }

            Id = id;
        }
    }
}