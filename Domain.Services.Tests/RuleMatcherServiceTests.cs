using System;
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

        // TODO: Complete this test
        [Fact]
        public void Matcher_method_should_return_a_list_of_rules()
        {
            Assert.True(false);
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
    }
}