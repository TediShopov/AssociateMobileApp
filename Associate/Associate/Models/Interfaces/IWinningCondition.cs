using System;
using System.Collections.Generic;
using System.Text;

namespace Associate.Models.Interfaces
{
    public interface IWinningCondition
    {
        int TotalPointsForTeam(ITeam team);
        int PointsPerTeamForStage(ITeam team,IStage stage);
        ITeam GetWinner(List<ITeam> teams);
        
    }
}
