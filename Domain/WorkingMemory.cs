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
            throw new NotImplementedException();
        }

        public void RemoveFact(Fact fact)
        {
            throw new NotImplementedException();
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