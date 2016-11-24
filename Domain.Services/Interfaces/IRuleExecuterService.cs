using System.Collections.Generic;

namespace Domain.Services.Interfaces
{
    public interface IRuleExecuterService
    {
        void Execute(WorkingMemory workingMemory, List<Rule> rules);
    }
}