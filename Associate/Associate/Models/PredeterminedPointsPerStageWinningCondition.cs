using Associate.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Associate.Models
{
    public class PredeterminedPointsPerStageWinningCondition : IWinningCondition
    {
        private readonly Dictionary<IStage, int> pointsPerStage;
        public List<IStage> Stage { get; set; }
        public List<ITeam> Teams { get; set; }
        public PredeterminedPointsPerStageWinningCondition(Dictionary<IStage,int> pointsPerStage)
        {
            this.pointsPerStage = pointsPerStage;
        }

        public PredeterminedPointsPerStageWinningCondition()
        {

        }
        public ITeam GetWinner()
        {
            ITeam winningTeam=this.Teams[0];
            int winningTeamPoints = 0;
            foreach (var team in this.Teams)
            {
                int teamPoints = this.TotalPointsForTeam(team);
                if (teamPoints>winningTeamPoints)
                {
                    winningTeam = team;
                    winningTeamPoints = teamPoints;
                }
            }
            return winningTeam;
        }

        public int PointsPerTeamForStage(ITeam team, IStage stage)
        {
            return team.GuessedWordsForStage(stage).Count*this.pointsPerStage[stage];
        }

        public int TotalPointsForTeam(ITeam team)
        {
            int totalPoints = 0;
            foreach (var stage in pointsPerStage.Keys)
            {
                totalPoints += PointsPerTeamForStage(team, stage);
            }
            return totalPoints;
        }
    }
}
