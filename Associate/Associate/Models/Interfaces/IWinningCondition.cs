using System;
using System.Collections.Generic;
using System.Text;

namespace Associate.Models.Interfaces
{
    public interface IWinningCondition
    {

         List<IStage> Stage { get; set; }
         List<ITeam> Teams { get; set; }
        int TotalPointsForTeam(ITeam team);
        int PointsPerTeamForStage(ITeam team,IStage stage);
        ITeam GetWinner();
        
    }
}
