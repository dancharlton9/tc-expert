using System.Collections.Generic;
using System.Linq;

namespace Domain.Preconditions
{
    public class ContainsPrecondition : Precondition
    {
        protected ContainsPrecondition()
        {

        }

        public override bool Evaluate(List<Fact> facts)
        {
            var result = facts.Where(x => x.Assertion == Fact.Assertion).ToList();
            return result.Count > 0;
        }

        public class Builder
        {
            private readonly ContainsPrecondition _precondition = new ContainsPrecondition();

            public Builder WithFact(Fact fact)
            {
                _precondition.SetFact(fact);
                return this;
            }

            public ContainsPrecondition Build()
            {
                return _precondition;
            }
        }
    }
}