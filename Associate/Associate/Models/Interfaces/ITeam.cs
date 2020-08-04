using System;
using System.Collections.Generic;
using System.Text;

namespace Associate.Models.Interfaces
{
    public interface ITeam
    {
        List<IPlayer> Members { get; set; }

        Dictionary<IStage, List<string>> GuessedWordsPerStage { get; }
        List<string> GuessedWordsForStage(IStage stage);

    }
}
