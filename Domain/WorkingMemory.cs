using System;
using System.Collections.Generic;

namespace Domain
{
    public class WorkingMemory
    {
        public List<Fact> Facts { get; private set; }

        protected WorkingMemory()
        {
            Facts = new List<Fact>();
        }

        public void AddFact(Fact fact)
        {
            if (fact == null) throw new ArgumentException("Fact should not be null.");
            Facts.Add(fact);
        }

        public void RemoveFact(Fact fact)
        {
            if (fact == null) throw new ArgumentException("Fact should not be null.");
            if (!Facts.Contains(fact)) throw new ArgumentException("Fact should already be in the collection.");
            Facts.Remove(fact);
        }

        public class Builder
        {
            private readonly WorkingMemory _workingMemory = new WorkingMemory();

            public WorkingMemory Build()
            {
                return _workingMemory;
            }
        }
    }
}