using Associate.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Associate.Models
{
    public class Stage : IStage
    {
        //TODO use base classes
        private IRound currentRound;
        public Stage(List<string> nonShuffledWords, IPlayerOrder playerOrder, TimeSpan timePerPlayer)
        {
            this.RemainingWords = ShuffleWords(nonShuffledWords);
            this.playerOrder = playerOrder;
            this.TimePerPlayer = timePerPlayer;
        }

        

        public Stage(Queue<string> shuffledWords,IPlayerOrder playerOrder, TimeSpan timePerPlayer)
        {
            this.RemainingWords = shuffledWords;
            this.playerOrder = playerOrder;
            this.TimePerPlayer = timePerPlayer;
        }
       
        public IRound CurrentRound { get { return currentRound; } }

        public IPlayerOrder playerOrder { get ; set ; }
        public Queue<string> InitialWords { get ; }
        public Queue<string> RemainingWords { get ; set ; }
        
        public TimeSpan TimePerPlayer { get ; set ; }

        public bool IsOver { get { return RemainingWords.Count == 0; } }
        public string GiveOutNewWordToGuess()
        {
            if (this.RemainingWords.Count != 0)
            {
                return this.RemainingWords.Peek();
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        public void SetUpPlayerRound()
        {
            if (this.playerOrder!=null)
            {
                this.currentRound = new Round(playerOrder.GoToNextPlayer(), this.TimePerPlayer,this);
            }
        }

        public void GuessWordForCurrentPlayer()
        {
            if (this.IsOver == false)
            {
                if (this.CurrentRound.RoundTimer.IsOver == false || this.CurrentRound.RoundTimer.IsStarted==true)
                {
                    this.CurrentRound.CurrentPlayer.GuessWordOnStage(this.RemainingWords.Dequeue(),this);
                }
            }
        }

        

        private Queue<string> ShuffleWords(List<string> nonShuffledWords)
        {
            Queue<string> shuffledWords = new Queue<string>();
            Random random = new Random();
            while (nonShuffledWords.Count != 0)
            {
                int randomIndex = random.Next(0, nonShuffledWords.Count);
                shuffledWords.Enqueue(nonShuffledWords[randomIndex]);


            }
            return shuffledWords;
        }




    }
}
