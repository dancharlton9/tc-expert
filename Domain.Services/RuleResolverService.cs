using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Services.Interfaces;

namespace Domain.Services
{
    public class RuleResolverService : IRuleResolverService
    {
        public List<Rule> Resolve(List<Rule> rules)
        {
            return rules.OrderBy(x => Guid.NewGuid()).ToList();
        }
    }
}