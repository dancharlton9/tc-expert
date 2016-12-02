using System.Collections.Generic;

namespace Domain.Actions
{
    public class AddRuleAction : RuleAction
    {
        public override void Execute(List<Fact> facts)
        {
            if (Fact == null) throw new ActionMissingFactException("Actions must have facts set to be executed.");
            if(!facts.Contains(Fact))
                facts.Add(Fact);
        }
    }
}