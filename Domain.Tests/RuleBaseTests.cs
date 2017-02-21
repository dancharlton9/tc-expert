using System;
using Xunit;

namespace Domain.Tests
{
    public class RuleBaseTests : IDisposable
    {
        private RuleBase _ruleBase;

        public RuleBaseTests()
        {
            _ruleBase = new RuleBase.Builder().Build();
        }

        public void Dispose()
        {
            _ruleBase = new RuleBase.Builder().Build();
        }

        [Fact]
        public void AddRule_should_add_the_passed_rule_to_the_Rules_collection()
        {
            // arrange
            var rule = new Rule(Guid.Empty);

            // act
            _ruleBase.AddRule(rule);

            // assert
            Assert.Contains(rule, _ruleBase.Rules);
        }

        [Fact]
        public void AddRule_should_throw_if_the_passed_rule_is_null()
        {
            Assert.Throws<ArgumentException>(() => _ruleBase.AddRule(null));
        }

        [Fact]
        public void RemoveRule_should_remove_the_passed_rule_from_the_Rules_collection()
        {
            // arrange
            var rule = new Rule(Guid.Empty);
            _ruleBase.AddRule(rule);

            // act
            _ruleBase.RemoveRule(rule);

            // assert
            Assert.DoesNotContain(rule, _ruleBase.Rules);
        }

        [Fact]
        public void RemoveRule_should_throw_if_the_passed_rule_is_null()
        {
            Assert.Throws<ArgumentException>(() => _ruleBase.RemoveRule(null));
        }

        [Fact]
        public void RemoveRule_should_throw_if_the_passed_rule_is_not_in_the_Rules_collection()
        {
            Assert.Throws<ArgumentException>(() => _ruleBase.RemoveRule(new Rule(Guid.Empty)));
        }

    }
}