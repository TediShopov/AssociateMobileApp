using Associate.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Associate.Models
{
    public class MostWordsGuessedWinningCondition : IWinningCondition
    {
        
        public List<IStage> Stage { get; set; }
        public List<ITeam> Teams { get; set; }
        public MostWordsGuessedWinningCondition()
        {
            
        }

        //Todo make for a draw
        public ITeam GetWinner()
        {
            ITeam winningTeam=this.Teams[0];
            int winnerPoints = 0;
            foreach (var team in this.Teams)
            {
                var totalPoints = 0;
                totalPoints = this.TotalPointsForTeam(team);
                if (totalPoints>winnerPoints)
                {
                    winnerPoints = totalPoints;
                    winningTeam = team;
                }
            }
            return winningTeam;
        }

        public int PointsPerTeamForStage(ITeam team, IStage stage)
        {
          return  team.GuessedWordsForStage(stage).Count;
        }

        public int TotalPointsForTeam(ITeam team)
        {
            int totalPoints = 0;
            foreach (var stage in this.Stage)
            {
                totalPoints += PointsPerTeamForStage(team,stage);
            }
            return totalPoints;
        }
    }
}
