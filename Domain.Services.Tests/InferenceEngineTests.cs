using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Actions;
using Domain.Preconditions;
using Xunit;

namespace Domain.Services.Tests
{
    public class InferenceEngineTests : IDisposable
    {
        private InferenceEngine _engine;

        public InferenceEngineTests()
        {
            _engine = new InferenceEngine.Builder().Build();
        }

        public void Dispose()
        {
            _engine = new InferenceEngine.Builder().Build();
        }

        [Fact]
        public void SetWorkingMemory_method_should_set_the_workingmemory_property()
        {
            // arrange
            var workingMemory = new WorkingMemory.Builder().Build();

            // act
            _engine.SetWorkingMemory(workingMemory);

            // assert
            Assert.Equal(workingMemory, _engine.GetWorkingMemory());
        }

        [Fact]
        public void SetWorkingMemory_method_should_throw_if_the_workingmemory_parameter_is_null()
        {
            Assert.Throws<ArgumentException>(() => _engine.SetWorkingMemory(null));
        }

        [Fact]
        public void SetRuleBase_method_should_set_the_rulebase_property()
        {
            // arrange
            var ruleBase = new RuleBase.Builder().Build();

            // act
            _engine.SetRuleBase(ruleBase);

            // assert
            Assert.Equal(ruleBase, _engine.GetRuleBase());
        }

        [Fact]
        public void SetRuleBase_method_should_throw_if_the_rulebase_parameter_is_null()
        {
            Assert.Throws<ArgumentException>(() => _engine.SetRuleBase(null));
        }

        [Fact]
        public void Builder_should_create_a_default_InferenceEngine_instance()
        {
            // act
            var engine = new InferenceEngine.Builder().Build();

            // assert
            Assert.IsType<InferenceEngine>(engine);
        }

        [Fact]
        public void Builder_WithWorkingMemory_method_should_set_the_workingmemory_property()
        {
            // arrange
            var workingMemory = new WorkingMemory.Builder().Build();

            // act
            var engine = new InferenceEngine.Builder()
                .WithWorkingMemory(workingMemory)
                .Build();

            // assert
            Assert.Equal(workingMemory, engine.GetWorkingMemory());
        }

        [Fact]
        public void Builder_WithRuleBase_method_should_set_the_rulebase_property()
        {
            // arrange
            var ruleBase = new RuleBase.Builder().Build();

            // act
            var engine = new InferenceEngine.Builder()
                .WithRuleBase(ruleBase)
                .Build();

            // assert
            Assert.Equal(ruleBase, engine.GetRuleBase());
        }

        [Fact]
        public void GetWorkingMemory_method_should_return_an_instance_of_WorkingMemory()
        {
            // arrange / act
            var workingMemory = _engine.GetWorkingMemory();

            // assert
            Assert.NotNull(workingMemory);
        }

        [Fact]
        public void GetRuleBase_method_should_return_an_instance_of_RuleBase()
        {
            // arrange / act
            var ruleBase = _engine.GetRuleBase();

            // assert
            Assert.NotNull(ruleBase);
        }

        [Fact]
        public void Match_method_should_return_a_list_of_Rule()
        {
            // arrange

            // act
            var rules = _engine.Match();

            // assert
            Assert.IsType<List<Rule>>(rules);
        }

        [Fact]
        public void Match_method_should_return_a_list_of_matching_rules()
        {
            // arrange
            var workingMemory = SeedWorkingMemory();
            var ruleBase = SeedRuleBase();
            var engine = new InferenceEngine.Builder()
                .WithWorkingMemory(workingMemory)
                .WithRuleBase(ruleBase)
                .Build();

            // act
            var rules = engine.Match();

            // assert
            Assert.Contains(ruleBase.Rules[0], rules);
        }

        [Fact]
        public void Match_method_should_return_an_empty_list_if_no_rules_match()
        {
            // arrange
            var workingMemory = SeedWorkingMemory();
            var ruleBase = SeedRuleBase(false);
            var engine = new InferenceEngine.Builder()
                .WithWorkingMemory(workingMemory)
                .WithRuleBase(ruleBase)
                .Build();

            // act
            var rules = engine.Match();

            // assert
            Assert.Equal(0, rules.Count);
        }

        [Fact]
        public void Resolve_method_should_return_a_list_of_Rule()
        {
            // act
            var rules = _engine.Resolve(new List<Rule>());

            // assert
            Assert.IsType<List<Rule>>(rules);
        }

        [Fact]
        public void Resolve_method_should_return_a_list_of_all_passed_rule()
        {
            // arrange
            var workingMemory = SeedWorkingMemory();
            var ruleBase = SeedRuleBase();
            var engine = new InferenceEngine.Builder()
                .WithWorkingMemory(workingMemory)
                .WithRuleBase(ruleBase)
                .Build();
            var rules = engine.Match();
            var matchCount = rules.Count;

            // act
            var resolvedRules = engine.Resolve(rules);
            var resolvedCount = resolvedRules.Count;

            // assert
            Assert.Equal(matchCount, resolvedCount);
        }

        [Fact]
        public void Execute_method_should_trigger_rule_actions_against_the_working_memory()
        {
            // arrange
            var workingMemory = SeedWorkingMemory();
            var ruleBase = SeedRuleBase();
            var engine = new InferenceEngine.Builder()
                .WithWorkingMemory(workingMemory)
                .WithRuleBase(ruleBase)
                .Build();
            var rules = engine.Match();
            var resolvedRules = engine.Resolve(rules);

            // act
            engine.Execute(resolvedRules);
            var newFacts = workingMemory.Facts;
            var potentialCSharp = newFacts.FirstOrDefault(x => x.Assertion == "Potential C# experience");
            var potentialAngular = newFacts.FirstOrDefault(x => x.Assertion == "Potential Angular experience");

            // assert
            Assert.IsType<Fact>(potentialCSharp);
            Assert.IsType<Fact>(potentialAngular);
        }


        private WorkingMemory SeedWorkingMemory()
        {
            var workingMemory = new WorkingMemory.Builder().Build();

            workingMemory.AddFact( new Fact()
            {
                Assertion = "Has .NET"
            });

            return workingMemory;
        }

        private RuleBase SeedRuleBase(bool withMatch = true)
        {
            var assertion = withMatch ? "Has .NET" : "Has no .NET";

            var ruleBase = new RuleBase.Builder().Build();

            var rule = new Rule(Guid.Empty);
            var fact = new Fact() { Assertion = assertion };
            var precondition = new ContainsPrecondition.Builder()
                .WithFact(fact)
                .Build();
            rule.AddPrecondition(precondition);

            var action1 = new AddRuleAction();
            action1.SetFact(new Fact()
            {
                Assertion = "Potential C# experience"
            });

            var action2 = new AddRuleAction();
            action2.SetFact(new Fact()
            {
                Assertion = "Potential Angular experience"
            });

            rule.AddRuleAction(action1);
            rule.AddRuleAction(action2);

            ruleBase.AddRule(rule);

            return ruleBase;
        }
    }
}