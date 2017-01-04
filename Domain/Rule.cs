using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Actions;
using Domain.Preconditions;

namespace Domain
{
    public class Rule
    {
        public List<Precondition> Preconditions { get; private set; }
        public List<RuleAction> Actions { get; private set; }
        public bool Triggered { get; private set; }

        public Rule()
        {
            Preconditions = new List<Precondition>();
            Actions = new List<RuleAction>();
            Triggered = false;
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

        public void AddRuleAction(RuleAction ruleAction)
        {
            if (ruleAction == null) throw new ArgumentException("Rule action must not be null.");
            Actions.Add(ruleAction);
        }

        public void RemoveRuleAction(RuleAction ruleAction)
        {
            if (ruleAction == null) throw new ArgumentException("Rule action must not be null.");
            if (!Actions.Contains(ruleAction))
                throw new ArgumentException("Rule action must already be present in the collection.");
            Actions.Remove(ruleAction);
        }

        public bool EvaluatePreconditions(List<Fact> facts)
        {
            return Preconditions.All(precondition => precondition.Evaluate(facts));
        }

        public void ExecuteActions(List<Fact> facts)
        {
            foreach (var a in Actions)
            {
                a.Execute(facts);
            }

            MarkAsTriggered();
        }

        public void MarkAsTriggered()
        {
            Triggered = true;
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