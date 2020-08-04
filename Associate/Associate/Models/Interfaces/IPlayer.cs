using System;
using System.Collections.Generic;
using System.Text;

namespace Associate.Models.Interfaces
{
    public interface IPlayer
    {
        Dictionary<IStage, List<string>> GuessedWordsPerStage { get; set; }
        string Name { get; set; }

        List<string> CreatedWords { get; }
        void AddCreatedWord(string words);
        void GuessWordOnStage(string word, IStage stage);
    }
}
