using System;
using System.Collections.Generic;
using Domain.Delegates;
using Domain.Interfaces;

namespace Domain
{
    public class Action : IAction
    {
        public Fact Fact { get; private set; }
        public Operation Operation { get; set; }

        public void SetFact(Fact fact)
        {
            throw new NotImplementedException();
        }

        public void SetOperation(Operation operation)
        {
            throw new NotImplementedException();
        }

        public void Execute(List<Fact> facts)
        {
            Operation(facts, Fact);
        }

        public class Builder
        {
            private readonly Action _action = new Action();

            public Builder WithFact(Fact fact)
            {
                _action.SetFact(fact);
                return this;
            }

            public Builder WithOperation(Operation operation)
            {
                _action.SetOperation(operation);
                return this;
            }

            public Action Build()
            {
                return _action;
            }
        }
    }
}