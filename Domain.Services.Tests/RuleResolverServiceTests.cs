using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Domain.Services.Tests
{
    public class RuleResolverServiceTests :  IDisposable
    {
        private RuleResolverService _resolver;

        public RuleResolverServiceTests()
        {
            _resolver = new RuleResolverService();
        }

        public void Dispose()
        {
            _resolver = new RuleResolverService();
        }

        [Fact]
        public void Resolve_method_should_return_a_list_Rule()
        {
            // arrange

            // act
            var rules = _resolver.Resolve(new List<Rule>());

            // assert
            Assert.IsType<List<Rule>>(rules);
        }

        [Fact]
        public void Resolve_method_should_return_all_selected_rules()
        {
            // arrange
            var rules = new List<Rule>();
            for (var i = 0; i < 5; i++)
            {
                rules.Add(new Rule());
            }

            // act
            var selectedRules = _resolver.Resolve(rules);
            var result = !selectedRules.Except(rules).Any();

            // assert
            Assert.True(result);
        }
    }
}