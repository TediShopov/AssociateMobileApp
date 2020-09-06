using Associate.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public int SkipsPerRound { get; set; }
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
                this.currentRound = new Round(playerOrder.GoToNextPlayer(), this.TimePerPlayer,this,this.SkipsPerRound);
            }
            else
            {
                throw new NullReferenceException("Player order is null");
            }
        }

        public void GuessWordForCurrentPlayer()
        {
            if (this.IsOver == false)
            {
                if (this.CurrentRound.RoundTimer.IsOver == false && this.CurrentRound.RoundTimer.IsStarted==true)
                {
                    this.CurrentRound.CurrentPlayer.GuessWordOnStage(this.RemainingWords.Dequeue(),this);
                }
            }
           
        }

        public bool SkipWord() 
        {
            bool skippedWord = false;
            if (this.CurrentRound.CanSkipWord)
            {
                skippedWord = true;
                this.CurrentRound.ConsumeOneSkip();
                Random random = new Random();
                var randomAmountOfWordsToSkip = random.Next(0, this.RemainingWords.Count);
                var listOfDequedWords = new List<string>();
                for (int i = 0; i < randomAmountOfWordsToSkip; i++)
                {
                    listOfDequedWords.Add(this.RemainingWords.Dequeue());
                }
                listOfDequedWords = listOfDequedWords.OrderBy(a => Guid.NewGuid()).ToList();
                foreach (var word in listOfDequedWords)
                {
                    this.RemainingWords.Enqueue(word);
                }
            }
            return skippedWord;
        }

        

        private Queue<string> ShuffleWords(List<string> nonShuffledWords)
        {
            var newNonShuffledWordList = new List<string>(nonShuffledWords);
            Queue<string> shuffledWords = new Queue<string>();
            Random random = new Random();
            while (newNonShuffledWordList.Count != 0)
            {
                int randomIndex = random.Next(0, newNonShuffledWordList.Count);
                
                shuffledWords.Enqueue(newNonShuffledWordList[randomIndex]);
                newNonShuffledWordList.RemoveAt(randomIndex);


            }
            return shuffledWords;
        }




    }
}
