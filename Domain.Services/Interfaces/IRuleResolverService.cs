using System.Collections.Generic;

namespace Domain.Services.Interfaces
{
    public interface IRuleResolverService
    {
        List<Rule> Resolve(List<Rule> rules);
    }
}