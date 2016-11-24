using System;
using Domain.Preconditions;

namespace Domain.Factories
{
    public class PreconditionFactory
    {
        public Precondition GenerateNewPrecondition<T>() where T : Precondition
        {
            if (typeof(T) == typeof(ContainsPrecondition))
                return new ContainsPrecondition.Builder().Build();
            if (typeof(T) == typeof(DoesNotContainPrecondition))
                return new DoesNotContainPrecondition.Builder().Build();

            throw new ArgumentException("Unknown precondition type.");
        }
    }
}