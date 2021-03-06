﻿using System;
using System.Collections.Generic;
using Domain.Services.Interfaces;

namespace Domain.Services
{
    public class InferenceEngine
    {
        private readonly IRuleMatcherService _matcher;
        private readonly IRuleResolverService _resolver;
        private readonly IRuleExecuterService _executer;

        private WorkingMemory _workingMemory;
        private RuleBase _ruleBase;

        protected InferenceEngine(WorkingMemory workingMemory, RuleBase ruleBase)
        {
            _workingMemory = workingMemory;
            _ruleBase = ruleBase;

            _matcher = new RuleMatcherService();
            _resolver = new RuleResolverService();
            _executer = new RuleExecuterService();
        }

        public void SetWorkingMemory(WorkingMemory workingMemory)
        {
            if (workingMemory == null) throw new ArgumentException("Working memory should not be null.");
            _workingMemory = workingMemory;
        }

        public void SetRuleBase(RuleBase ruleBase)
        {
            if (ruleBase == null) throw new ArgumentException("Rule base should not be null.");
            _ruleBase = ruleBase;
        }

        public WorkingMemory GetWorkingMemory()
        {
            return _workingMemory;
        }

        public RuleBase GetRuleBase()
        {
            return _ruleBase;
        }

        public List<Rule> Match()
        {
            return _matcher.Match(_workingMemory, _ruleBase);
        }

        public List<Rule> Resolve(List<Rule> rules)
        {
            return _resolver.Resolve(rules);
        }

        public void Execute(List<Rule> rules)
        {
            _executer.Execute(_workingMemory, rules);
        }

        public class Builder
        {
            private readonly InferenceEngine _engine;

            public Builder()
            {
                var workingMemory = new WorkingMemory.Builder().Build();
                var ruleBase = new RuleBase.Builder().Build();
                _engine = new InferenceEngine(workingMemory, ruleBase);
            }

            public Builder WithWorkingMemory(WorkingMemory workingMemory)
            {
                _engine.SetWorkingMemory(workingMemory);
                return this;
            }

            public Builder WithRuleBase(RuleBase ruleBase)
            {
                _engine.SetRuleBase(ruleBase);
                return this;
            }

            public InferenceEngine Build()
            {
                return _engine;
            }
        }
    }
}