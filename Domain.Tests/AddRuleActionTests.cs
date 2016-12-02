using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Actions;
using Domain.Interfaces;
using Xunit;

namespace Domain.Tests
{
    public class AddRuleActionTests : RuleActionTests<AddRuleAction>, IDisposable
    {
        private RuleAction _action;

        public AddRuleActionTests()
        {
            _action = new AddRuleAction();
        }

        public void Dispose()
        {
            _action = new AddRuleAction();
        }

        public override IRuleAction CreateAction()
        {
            return new AddRuleAction();
        }

        [Fact]
        public void Execute_should_add_the_fact_to_the_facts_collection()
        {
            // arrange
            var fact = new Fact()
            {
                Assertion = "Has a dog"
            };
            _action.SetFact(fact);
            var facts = new List<Fact>();

            // act
            _action.Execute(facts);

            // assert
            Assert.Contains(fact, facts);
        }

        [Fact]
        public void Execute_should_not_add_the_fact_to_the_facts_collection_if_the_fact_is_already_present()
        {
            // arrange
            var fact = new Fact()
            {
                Assertion = "Has a dog"
            };
            _action.SetFact(fact);
            var facts = new List<Fact>
            {
                fact
            };

            // act
            _action.Execute(facts);
            var matchingFacts = facts.Where(x => x == fact).ToList();

            // assert
            Assert.Equal(1, matchingFacts.Count);
        }

        [Fact]
        public void Execute_should_throw_if_the_fact_is_null()
        {
            Assert.Throws<ActionMissingFactException>(() => _action.Execute(new List<Fact>()));
        }
    }
}