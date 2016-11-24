using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IPrecondition
    {
        Fact Fact { get; }
        void SetFact(Fact fact);
        bool Evaluate(List<Fact> facts);
    }
}