using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Preconditions;

namespace Domain
{
    public class Rule
    {
        public List<Precondition> Preconditions { get; private set; }
        public List<Action> Actions { get; private set; }

        public Rule()
        {
            Preconditions = new List<Precondition>();
            Actions = new List<Action>();
        }

        public void AddPrecondition(Precondition precondition)
        {
            if (precondition == null) throw new ArgumentException("Precondition should not be null.");
            Preconditions.Add(precondition);
        }

        public void RemovePrecondition(Precondition precondition)
        {
            if (precondition == null) throw new ArgumentException("Precondition should not be null.");
            if (!Preconditions.Contains(precondition)) throw new ArgumentException();
            Preconditions.Remove(precondition);
        }

        public void AddAction(Action action)
        {
            throw new NotImplementedException();
        }

        public void RemoveAction(Action action)
        {
            throw new NotImplementedException();
        }

        public bool EvaluatePreconditions(List<Fact> facts)
        {
            return Preconditions.All(precondition => precondition.Evaluate(facts));
        }

        public void ExecuteActions(List<Fact> facts)
        {
            foreach (var a in Actions)
            {
                a.Operation(facts, a.Fact);
            }
        }

        public class Builder
        {
            private readonly Rule _rule = new Rule();

            public Rule Build()
            {
                return _rule;
            }
        }
    }
}