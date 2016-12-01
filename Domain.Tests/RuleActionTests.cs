using System;
using Domain.Actions;
using Domain.Interfaces;
using Xunit;

namespace Domain.Tests
{
    public abstract class RuleActionTests<T> where T : RuleAction
    {
        public abstract IRuleAction CreateAction();

        [Fact]
        public void SetFact_should_set_the_fact_property()
        {
            // arrange
            var action = CreateAction();
            var fact = new Fact() { Assertion = Guid.NewGuid().ToString() };

            // act
            action.SetFact(fact);

            // assert
            Assert.Equal(fact, action.Fact);
        }

        [Fact]
        public void SetFact_should_throw_if_the_fact_is_null()
        {
            // arrange
            var action = CreateAction();

            // assert
            Assert.Throws<ArgumentException>(() => action.SetFact(null));
        }
    }
}