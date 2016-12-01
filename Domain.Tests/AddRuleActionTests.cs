using Domain.Actions;
using Domain.Interfaces;
using Xunit;

namespace Domain.Tests
{
    public class AddRuleActionTests : RuleActionTests<AddRuleAction>
    {
        public override IRuleAction CreateAction()
        {
            return new AddRuleAction();
        }

        [Fact]
        public void Execute_should_add_the_fact_to_the_facts_collection()
        {
            Assert.True(false);
        }

        [Fact]
        public void Execute_should_not_add_the_fact_to_the_facts_collection_if_the_fact_is_already_present()
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