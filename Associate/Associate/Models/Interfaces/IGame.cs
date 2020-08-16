using System;
using System.Collections.Generic;
using System.Text;

namespace Associate.Models.Interfaces
{
    public interface IGame
    {
        IStage CurrentStage { get; }
        IWinningCondition winningCondition { get; set; }

        //Stage might be IEnumrator<Stage> -- MoveNext() method and current;
        List<IStage> Stages { get; }
        List<ITeam> Teams { get; set; }

        int NumberOfStages { get;  }
        int NumberOfPlayers { get; }
        bool IsFinished { get; }

        int CurrentStageNumber { get; }
        void GoToNextStage();

       

       
       

    }
}
