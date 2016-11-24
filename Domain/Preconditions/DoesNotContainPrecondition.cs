using System.Collections.Generic;
using System.Linq;

namespace Domain.Preconditions
{
    public class DoesNotContainPrecondition : Precondition
    {
        protected DoesNotContainPrecondition()
        {

        }

        public override bool Evaluate(List<Fact> facts)
        {
            var result = facts.Where(x => x.Assertion == Fact.Assertion).ToList();
            return result.Count == 0;
        }

        public class Builder
        {
            private readonly DoesNotContainPrecondition _precondition = new DoesNotContainPrecondition();

            public Builder WithFact(Fact fact)
            {
                _precondition.SetFact(fact);
                return this;
            }

            public Precondition Build()
            {
                return _precondition;
            }
        }
    }
}