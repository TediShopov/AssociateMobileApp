using Associate.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Associate.Models
{
    public class Round : IRound
    {
        private IStage currentStage;
        public Round(IPlayer player,TimeSpan timePerPlayer,IStage stage)
        {
            this.currentStage = stage;
            this.CurrentPlayer = player;
            this.RoundTimer = new RoundTimer(timePerPlayer);
           
        }

        public IPlayer CurrentPlayer { get;  }
        public string CurrentPlayerName { get {return this.CurrentPlayer.Name; } }

        public IRoundTimer RoundTimer { get; }

        


       

    }
}
