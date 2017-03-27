using System.Collections.Generic;
using Domain.Services.Exceptions;
using Domain.Services.Interfaces;
using Xunit;

namespace Domain.Services.Tests
{
    public class RuleExecuterServiceTests
    {
        public IRuleExecuterService _service;

        public RuleExecuterServiceTests()
        {
            _service = new RuleExecuterService();
        }

        [Fact]
        public void Execute_method_should_throw_if_the_working_memory_is_null()
        {
            // assert
            Assert.Throws<InvalidWorkingMemoryException>(() => _service.Execute(null, new List<Rule>()));
        }

        [Fact]
        public void Execute_method_should_update_the_working_memory_by_applying_rules()
        {
            // arrange

            // act

            // assert
        }

        [Fact]
        public void Execute_method_should_not_update_the_working_memory_when_there_are_no_rules_to_apply()
        {
            // arrange

            // act

            // assert
        }
    }
}