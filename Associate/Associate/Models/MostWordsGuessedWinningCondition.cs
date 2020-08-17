using Associate.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Associate.Models
{
    public class MostWordsGuessedWinningCondition : IWinningCondition
    {
        private readonly List<IStage> stages;

        public MostWordsGuessedWinningCondition(List<IStage> stages)
        {
            this.stages = stages;
        }

        //Todo make for a draw
        public ITeam GetWinner(List<ITeam> teams)
        {
            ITeam winningTeam=teams[0];
            int winnerPoints = 0;
            foreach (var team in teams)
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
            foreach (var stage in this.stages)
            {
                totalPoints += PointsPerTeamForStage(team,stage);
            }
            return totalPoints;
        }
    }
}
