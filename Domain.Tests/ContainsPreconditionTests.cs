using System;
using System.Collections.Generic;
using Domain.Factories;
using Domain.Interfaces;
using Domain.Preconditions;
using Xunit;

namespace Domain.Tests
{
    public class ContainsPreconditionTests : PreconditionTests<ContainsPrecondition>, IDisposable
    {
        private Precondition _precondition;
        private List<Fact> _facts;
        private readonly PreconditionFactory _factory;

        public ContainsPreconditionTests()
        {
            _factory = new PreconditionFactory();
            _precondition = _factory.GenerateNewPrecondition<ContainsPrecondition>();
            _facts = new List<Fact>();
        }

        public void Dispose()
        {
            _precondition = _factory.GenerateNewPrecondition<ContainsPrecondition>();
            _facts = new List<Fact>();
        }

        protected override IPrecondition CreatePrecondition()
        {
            return _factory.GenerateNewPrecondition<ContainsPrecondition>();
        }

        [Fact]
        public void Evaluate_method_should_return_a_bool_value()
        {
            // act
            var result = _precondition.Evaluate(_facts);

            // assert
            Assert.IsType<bool>(result);
        }

        [Fact]
        public void Evaluate_method_should_return_true_if_preconditions_match_facts()
        {
            // arrange
            var factAssertion = Guid.NewGuid().ToString();

            _facts.Add(new Fact()
            {
                Assertion = factAssertion
            });

            var fact = new Fact
            {
                Assertion = factAssertion
            };
            _precondition.SetFact(fact);

            // act
            var result = _precondition.Evaluate(_facts);

            // assert
            Assert.True(result);
        }

        [Fact]
        public void Evaluate_method_should_return_false_if_preconditions_do_not_match_facts()
        {
            // arrange
            _facts.Add(new Fact()
            {
                Assertion = Guid.NewGuid().ToString()
            });

            var fact = new Fact
            {
                Assertion = Guid.NewGuid().ToString()
            };
            _precondition.SetFact(fact);

            // act
            var result = _precondition.Evaluate(_facts);

            // assert
            Assert.False(result);
        }
    }
}