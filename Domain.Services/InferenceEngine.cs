using System;
using Domain.Services.Interfaces;

namespace Domain.Services
{
    public class InferenceEngine
    {
        private IRuleMatcherService _matcher;
        private IRuleResolverService _resolver;
        private IRuleExecuterService _executer;

        private WorkingMemory _workingMemory;
        private RuleBase _ruleBase;

        public InferenceEngine(WorkingMemory workingMemory, RuleBase ruleBase)
        {
            _workingMemory = workingMemory;
            _ruleBase = ruleBase;

            _matcher = new RuleMatcherService();
            _resolver = new RuleResolverService();
            _executer = new RuleExecuterService();
        }

        public void Match()
        {
            throw new NotImplementedException();
        }

        public void Resolve()
        {
            throw new NotImplementedException();
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}