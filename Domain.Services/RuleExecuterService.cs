using System.Collections.Generic;
using Domain.Services.Interfaces;

namespace Domain.Services
{
    public class RuleExecuterService : IRuleExecuterService
    {
        public void Execute(WorkingMemory workingMemory, List<Rule> rules)
        {
            var facts = workingMemory.Facts;

            foreach (var rule in rules)
            {
                foreach (var action in rule.Actions)
                {
                    action.Execute(facts);
                }
            }
        }
    }
}