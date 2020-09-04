using System;
using System.Collections.Generic;
using System.Text;

namespace Associate.Models.Interfaces
{
    public interface IStage
    {

         
        IRound CurrentRound { get; }

        IPlayerOrder playerOrder { get; set; }

        void GuessWordForCurrentPlayer();
        Queue<string> InitialWords { get;  }
        Queue<string> RemainingWords { get; set; }

        TimeSpan TimePerPlayer { get; set; }

        bool IsOver { get; }
        void SetUpPlayerRound();
        string GiveOutNewWordToGuess();



    }
}
