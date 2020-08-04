using Associate.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Associate.Models
{
    public class Player : IPlayer
    {
        public Player()
        {
            this.GuessedWordsPerStage = new Dictionary<IStage, List<string>>();
            this.CreatedWords = new List<string>();
        }
        public Dictionary<IStage, List<string>> GuessedWordsPerStage { get; set; }
        public string Name { get; set; }

        public List<string> CreatedWords { get; }

        public void AddCreatedWord(string words)
        {
            this.CreatedWords.Add(words);
        }

        public void GuessWordOnStage(string word, IStage stage)
        {
            if (this.GuessedWordsPerStage.ContainsKey(stage))
            {
                if (this.GuessedWordsPerStage[stage]!=null)
                {
                    this.GuessedWordsPerStage[stage].Add(word);
                }
                else
                {
                    this.GuessedWordsPerStage.Add(stage, new List<string> { word });
                }
            }
        }
    }
}
