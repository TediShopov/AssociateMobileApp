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
        public Round(IPlayer player,TimeSpan timePerPlayer,IStage stage,int skipsPerRound=0)
        {
            
            this.currentStage = stage;
            SkipsPerRound = skipsPerRound;
            this.CurrentPlayer = player;
            player.PlayerParticipateInStage(stage);
            this.RoundTimer = new RoundTimer(timePerPlayer);
           
        }
        

        public IPlayer CurrentPlayer { get;  }
        private int SkipsPerRound;
        public bool CanSkipWord { get { return this.SkipsPerRound > 0; } }
        public void ConsumeOneSkip() 
        {
            SkipsPerRound--;
        }
       
        public string CurrentPlayerName { get {return this.CurrentPlayer.Name; } }

        public IRoundTimer RoundTimer { get; }

        


       

    }
}
