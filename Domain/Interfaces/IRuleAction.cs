using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IRuleAction
    {
        Fact Fact { get; }
        void SetFact(Fact fact);
        void Execute(List<Fact> facts);
    }
}