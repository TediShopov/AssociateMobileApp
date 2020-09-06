using Associate.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Associate.Models
{
    public class Team : ITeam
    {
        public Team()
        {
            this.Members = new List<IPlayer>();
        }
        public Team(string name)
        {
            this.Members = new List<IPlayer>();
            this.Name = name;
        }
        public List<IPlayer> Members { get ; set ; }

        public List<string> GuessedWordsForStage(IStage stage)
        {
            List<string> listOfGuessedWords = new List<string>();
            foreach (var member in this.Members)
            {
                listOfGuessedWords.AddRange(member.GuessedWordsPerStage[stage]);
            }
            return listOfGuessedWords;
        }

       

        public Dictionary<IStage, List<string>> GuessedWordsPerStage {
            get 
            {
                Dictionary<IStage, List<string>> ret = new Dictionary<IStage, List<string>>();
                foreach (var key in this.Members[0].GuessedWordsPerStage.Keys)
                {
                    ret.Add(key, new List<string>());
                } 
                foreach (var member in Members)
                {
                    foreach (var stage in member.GuessedWordsPerStage.Keys)
                    {
                        ret[stage].AddRange(member.GuessedWordsPerStage[stage]);
                    }
                }
                return ret;
            }
                }

        public string Name { get ; set ; }
    }
}
