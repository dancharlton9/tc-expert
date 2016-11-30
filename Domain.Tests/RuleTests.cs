using System;
using System.Collections.Generic;
using Domain.Factories;
using Domain.Preconditions;
using Xunit;

namespace Domain.Tests
{
    public class RuleTests : IDisposable
    {
        private Rule _rule;
        private readonly PreconditionFactory _factory;
        private readonly List<Fact> _facts;

        public RuleTests()
        {
            _factory = new PreconditionFactory();
            _rule = new Rule();
            _facts = GenerateFacts();
        }

        public void Dispose()
        {
            _rule = new Rule();
        }

        [Fact]
        public void AddPrecondition_should_add_the_passed_precondition_to_the_preconditions_collection()
        {
            // arrange
            var precondition = _factory.GenerateNewPrecondition<ContainsPrecondition>();

            // act
            _rule.AddPrecondition(precondition);

            // assert
            Assert.Contains(precondition, _rule.Preconditions);
        }

        [Fact]
        public void AddPrecondition_should_throw_if_the_passed_precondition_is_null()
        {
            Assert.Throws<ArgumentException>(() => _rule.AddPrecondition(null));
        }

        [Fact]
        public void RemovePrecondition_should_remove_the_passed_precondition_from_the_preconditions_collection()
        {
            // arrange
            var precondition = _factory.GenerateNewPrecondition<ContainsPrecondition>();
            _rule.AddPrecondition(precondition);

            // act
            _rule.RemovePrecondition(precondition);

            // assert
            Assert.DoesNotContain(precondition, _rule.Preconditions);
        }

        [Fact]
        public void RemovePrecondition_should_throw_if_the_passed_precondition_is_null()
        {
            Assert.Throws<ArgumentException>(() => _rule.RemovePrecondition(null));
        }

        [Fact]
        public void RemovePrecondition_should_throw_if_the_passed_precondition_is_not_in_the_preconditions_collection()
        {
            // arrange
            var precondition = _factory.GenerateNewPrecondition<ContainsPrecondition>();

            // assert
            Assert.Throws<ArgumentException>(() => _rule.RemovePrecondition(precondition));
        }

        [Fact]
        public void EvaluatePreconditions_should_return_a_boolean_result()
        {
            // arrange
            _rule.AddPrecondition(GenerateMatchingPrecondition());

            // act
            var result = _rule.EvaluatePreconditions(_facts);

            // assert
            Assert.IsType<bool>(result);
        }

        [Fact]
        public void EvaluatePreconditions_should_return_true_if_all_preconditions_are_satisfied_by_the_facts()
        {
            // arrange
            _rule.AddPrecondition(GenerateMatchingPrecondition());

            // act
            var result = _rule.EvaluatePreconditions(_facts);

            // assert
            Assert.True(result);
        }

        [Fact]
        public void EvaluatePreconditions_should_return_false_if_any_precondition_is_not_satisfied_by_the_facts()
        {
            // arrange
            _rule.AddPrecondition(GenerateNoneMatchingPrecondition());

            // act
            var result = _rule.EvaluatePreconditions(_facts);

            // assert
            Assert.False(result);
        }

        [Fact]
        public void AddAction_should_add_an_action_to_the_actions_collection()
        {
            Assert.True(false);
        }

        [Fact]
        public void AddAction_should_throw_if_the_passed_action_is_null()
        {
            Assert.True(false);
        }

        [Fact]
        public void RemoveAction_should_remove_an_action_from_the_actions_collection()
        {
            Assert.True(false);
        }

        [Fact]
        public void RemoveAction_should_throw_if_the_action_is_not_in_the_actions_collections()
        {
            Assert.True(false);
        }

        [Fact]
        public void RemoveAction_should_throw_if_the_action_is_null()
        {
            Assert.True(false);
        }

        [Fact]
        public void ExecuteActions_should_execute_actions_in_the_actions_collection__against_a_list_of_facts()
        {
            Assert.True(false);
        }

        private static List<Fact> GenerateFacts()
        {
            var facts = new List<Fact>
            {
                new Fact()
                {
                    Assertion = Guid.NewGuid().ToString()
                }
            };
            return facts;
        }

        private Precondition GenerateMatchingPrecondition()
        {
            var precondition = _factory.GenerateNewPrecondition<ContainsPrecondition>();
            precondition.SetFact(new Fact()
            {
                Assertion = _facts[0].Assertion
            });
            return precondition;
        }

        private Precondition GenerateNoneMatchingPrecondition()
        {
            var precondition = _factory.GenerateNewPrecondition<DoesNotContainPrecondition>();
            precondition.SetFact(new Fact()
            {
                Assertion = _facts[0].Assertion
            });
            return precondition;
        }
    }
}