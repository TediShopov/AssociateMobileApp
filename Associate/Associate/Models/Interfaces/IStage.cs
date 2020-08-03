using System;
using System.Collections.Generic;
using System.Text;

namespace Associate.Models.Interfaces
{
    public interface IStage
    {
        bool IsOver { get; }
        IRound CurrentRound {get;}
        //IPlayerOrder playerOrder {get;set;}

        int PointPerWordGuess { get; set; }

        void WordGuessed();
        void SetUpPlayerRound();
        void StartPlayerRoundTimer();

        
    }
}
