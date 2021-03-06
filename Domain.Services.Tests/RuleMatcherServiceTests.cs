﻿using System;
using System.Collections.Generic;
using Domain.Preconditions;
using Xunit;

namespace Domain.Services.Tests
{
    public class RuleMatcherServiceTests : IDisposable
    {
        private WorkingMemory _workingMemory;
        private RuleBase _ruleBase;
        private RuleMatcherService _matcher;

        public RuleMatcherServiceTests()
        {
            _workingMemory = GenerateWorkingMemory();
            _ruleBase = GenerateRuleBase();
            _matcher = new RuleMatcherService();
        }

        public void Dispose()
        {
            _workingMemory = GenerateWorkingMemory();
            _ruleBase = GenerateRuleBase();
            _matcher = new RuleMatcherService();
        }

        [Fact]
        public void Matcher_method_should_return_a_list_of_rules()
        {
            // arrange

            // act
            var result = _matcher.Match(_workingMemory, _ruleBase);

            // assert
            Assert.IsType<List<Rule>>(result);
        }

        [Fact]
        public void Matcher_method_should_not_return_rules_that_are_marked_as_triggered()
        {
            // arrange
            var assertion = Guid.NewGuid().ToString();

            AddFact(assertion);
            AddTriggeredRule(assertion);

            // act
            var result = _matcher.Match(_workingMemory, _ruleBase);

            // assert
            Assert.Equal(0, result.Count);
        }

        private static RuleBase GenerateRuleBase()
        {
            var ruleBase = new RuleBase.Builder().Build();
            return ruleBase;
        }

        private static WorkingMemory GenerateWorkingMemory()
        {
            var workingMemory = new WorkingMemory.Builder().Build();
            return workingMemory;
        }

        public void AddFact(string assertion)
        {
            var fact = new Fact()
            {
                Assertion = assertion
            };
            _workingMemory.AddFact(fact);
        }

        public void AddTriggeredRule(string assertion)
        {
            var fact = new Fact()
            {
                Assertion = assertion
            };
            var precondition = new ContainsPrecondition.Builder().WithFact(fact).Build();
            var rule = new Rule.Builder().Build();
            rule.AddPrecondition(precondition);
            rule.MarkAsTriggered();

            _ruleBase.AddRule(rule);
        }
    }
}