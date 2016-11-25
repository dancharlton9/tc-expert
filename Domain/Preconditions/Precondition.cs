using System;
using System.Collections.Generic;
using Domain.Interfaces;

namespace Domain.Preconditions
{
    public abstract class Precondition : IPrecondition
    {
        public Fact Fact { get; private set; }

        public void SetFact(Fact fact)
        {
            if (fact == null) throw new ArgumentException("Passed fact should not be null.");
            Fact = fact;
        }

        public abstract bool Evaluate(List<Fact> facts);
    }
}