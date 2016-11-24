using System;
using System.Collections.Generic;

namespace Domain
{
    public class RuleBase
    {
        public List<Rule> Rules { get; private set; }

        protected RuleBase()
        {
            Rules = new List<Rule>();
        }

        public void AddRule(Rule rule)
        {
            if (rule == null) throw new ArgumentException("Rule should not be null.");
            Rules.Add(rule);
        }

        public void RemoveRule(Rule rule)
        {
            if (rule == null) throw new ArgumentException("Rule should not be null.");
            if (!Rules.Contains(rule)) throw new ArgumentException("Rule should already be present in the collection.");
            Rules.Remove(rule);
        }

        public class Builder
        {
            private readonly RuleBase _ruleBase = new RuleBase();

            public RuleBase Build()
            {
                return _ruleBase;
            }
        }
    }
}