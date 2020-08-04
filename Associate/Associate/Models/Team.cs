using Associate.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Associate.Models
{
    public class Team : ITeam
    {
        public List<IPlayer> Members { get ; set ; }

        public int GuessedWordsForStage(IStage stage)
        {
            int guessedWordCount=0;
            foreach (var member in this.Members)
            {
                guessedWordCount += member.GuessedWordsPerStage[stage].Count;
            }
            return guessedWordCount;
        }
    }
}
