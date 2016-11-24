using System.Collections.Generic;
using System.Linq;
using Domain.Services.Interfaces;

namespace Domain.Services
{
    public class RuleMatcherService : IRuleMatcherService
    {
        public List<Rule> Match(WorkingMemory workingMemory, RuleBase ruleBase)
        {
            var matchingRules = ruleBase.Rules
                .Where(rule => rule.EvaluatePreconditions(workingMemory.Facts))
                .ToList();

            return matchingRules;
        }
    }
}