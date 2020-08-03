using System;
using System.Collections.Generic;
using System.Text;

namespace Associate.Models.Interfaces
{
    public interface IGame
    {

        int NumberOfStages { get;  }
        int NumberOfPlayers { get; }

        bool IsFinished { get; }

        IStage currentStage { get; }
        List<IStage> Stages { get; }
        int currentStageNumber { get; }
        void GoToNextStage();


        //Team GetWinner();
       

    }
}
