using Domain.Actions;
using Domain.Interfaces;
using Xunit;

namespace Domain.Tests
{
    public class RemoveRuleActionTests : RuleActionTests<AddRuleAction>
    {
        public override IRuleAction CreateAction()
        {
            return new RemoveRuleAction();
        }

        [Fact]
        public void Execute_should_remove_the_fact_from_the_facts_collection()
        {
            Assert.True(false);
        }

        [Fact]
        public void Execute_should_throw_if_the_fact_is_null()
        {
            Assert.True(false);
        }
    }
}