using System;
using Xunit;

namespace Domain.Tests
{
    public class WorkingMemoryTests : IDisposable
    {
        private WorkingMemory _workingMemory;

        public WorkingMemoryTests()
        {
            _workingMemory = new WorkingMemory.Builder().Build();
        }

        public void Dispose()
        {
            _workingMemory = new WorkingMemory.Builder().Build();
        }

        [Fact]
        public void AddFact_should_add_a_fact_to_the_Facts_collection()
        {
            // arrange
            var fact = new Fact();

            // act
            _workingMemory.AddFact(fact);

            // assert
            Assert.Contains(fact, _workingMemory.Facts);
        }

        [Fact]
        public void AddFact_should_throw_if_the_fact_is_null()
        {
            Assert.Throws<ArgumentException>(() => _workingMemory.AddFact(null));
        }

        [Fact]
        public void RemoveFact_should_remove_a_fact_from_the_Facts_collection()
        {
            // arrange
            var fact = new Fact();
            _workingMemory.AddFact(fact);

            // act
            _workingMemory.RemoveFact(fact);

            // assert
            Assert.DoesNotContain(fact, _workingMemory.Facts);
        }

        [Fact]
        public void RemoveFact_should_throw_fs_the_fact_is_null()
        {
            Assert.Throws<ArgumentException>(() => _workingMemory.RemoveFact(null));
        }

        [Fact]
        public void RemoveFact_should_throw_if_the_fact_is_not_currently_in_the_collection()
        {
            Assert.Throws<ArgumentException>(() => _workingMemory.RemoveFact(new Fact()));
        }
    }
}