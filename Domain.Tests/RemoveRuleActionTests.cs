using System;
using System.Collections.Generic;
using Domain.Actions;
using Domain.Interfaces;
using Xunit;

namespace Domain.Tests
{
    public class RemoveRuleActionTests : RuleActionTests<AddRuleAction>, IDisposable
    {
        private RemoveRuleAction _action;

        public RemoveRuleActionTests()
        {
            _action = new RemoveRuleAction();
        }

        public void Dispose()
        {
            _action = new RemoveRuleAction();
        }

        public override IRuleAction CreateAction()
        {
            return new RemoveRuleAction();
        }

        [Fact]
        public void Execute_should_remove_the_fact_from_the_facts_collection()
        {
            // arrange
            var fact = new Fact()
            {
                Assertion = "Has a dog"
            };
            var facts = new List<Fact>
            {
                fact
            };
            _action.SetFact(fact);

            // act
            _action.Execute(facts);

            // assert
            Assert.DoesNotContain(fact, facts);
        }

        [Fact]
        public void Execute_should_throw_if_the_fact_is_null()
        {
            Assert.Throws<ActionMissingFactException>(() => _action.Execute(new List<Fact>()));
        }
    }
}