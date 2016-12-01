using System;
using System.Collections.Generic;
using Domain.Interfaces;

namespace Domain.Actions
{
    public abstract class RuleAction : IRuleAction
    {
        public Fact Fact { get; private set; }

        public void SetFact(Fact fact)
        {
            if (fact == null) throw new ArgumentException("Fact should not be null.");
            Fact = fact;
        }

        public abstract void Execute(List<Fact> facts);
    }
}