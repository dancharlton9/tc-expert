using System;
using System.ComponentModel.DataAnnotations;
using Domain.Interfaces;
using Domain.Preconditions;
using Xunit;

namespace Domain.Tests
{
    public abstract class PreconditionTests<T> where T : Precondition
    {
        protected abstract IPrecondition CreatePrecondition();

        [Fact]
        public void SetFact_should_set_the_fact_property()
        {
            // arrange
            var precondition = CreatePrecondition();
            var fact = new Fact();

            // act
            precondition.SetFact(fact);

            // assert
            Assert.Equal(fact, precondition.Fact);
        }

        [Fact]
        public void SetFact_should_throw_if_the_passed_fact_is_null()
        {
            // arrange
            var precondition = CreatePrecondition();

            // assert
            Assert.Throws<ArgumentException>(() => precondition.SetFact(null));
        }
    }
}