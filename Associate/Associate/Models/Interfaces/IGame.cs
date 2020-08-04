using System;
using System.Collections.Generic;
using System.Text;

namespace Associate.Models.Interfaces
{
    public interface IGame
    {
        IStage CurrentStage { get; }
        ITeam GetWinner();
        List<IStage> Stages { get; }
        List<ITeam> Teams { get; set; }

        int NumberOfStages { get;  }
        int NumberOfPlayers { get; }
        bool IsFinished { get; }

        int CurrentStageNumber { get; }
        void GoToNextStage();

       

       
       

    }
}
