using System.Collections.Generic;

namespace Domain.Services.Interfaces
{
    public interface IRuleMatcherService
    {
        List<Rule> Match(WorkingMemory workingMemory, RuleBase ruleBase);
    }
}