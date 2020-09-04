using Associate.Models.Interfaces;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Associate.ViewModels
{
    public class WordEnterViewModel : INotifyPropertyChanged
    {
        public class EnteredWord{
            public EnteredWord(string words)
            {
                this.Word = words;
            }
            public string Word { get; set; }
        }
        private int numberOfPlayersInGame;
        private int numberOfPlayersEnteredWords = 1;
        public event PropertyChangedEventHandler PropertyChanged;
        public WordEnterViewModel(IPlayerOrder playerOrder,int numberOfWordsPerPlayer)
        {
            this.playerOrder = playerOrder;
            this.GoToNextPlayerCommand = new Command(GoToNextPlayer);
            this.numberOfPlayersInGame = playerOrder.Order.Count;
            this.EnteredWords = InitializeEnteredWords(numberOfWordsPerPlayer);
            this.StartButtonVisible = false;
            this.NextPlayerButtonVisible = true;
            this.CurrentPlayer = this.playerOrder.GoToNextPlayer();
            this.UnshuffledWords = new List<string>();
        }

        private ObservableCollection<EnteredWord> InitializeEnteredWords(int numberOfWordsPerPlayer)
        {
            var enteredWords = new ObservableCollection<EnteredWord>();
            string wordPrefix = "Word";
            for (int i = 1; i <= numberOfWordsPerPlayer; i++)
            {
                enteredWords.Add(new EnteredWord(wordPrefix + i.ToString()));

            }
            return enteredWords;
        }

        public ObservableCollection<EnteredWord> EnteredWords { get; set; }


        public IPlayerOrder playerOrder { get; set; }

        [AlsoNotifyFor("NextPlayer")]
        public IPlayer CurrentPlayer { get; set; }

        public List<string> UnshuffledWords { get; set; }

        public IPlayer NextPlayer { get { return playerOrder.PeekNextPlayer(); } }

        public bool StartButtonVisible { get; set; }

        public bool NextPlayerButtonVisible { get; set; }
        public ICommand GoToNextPlayerCommand { get; set; }
        public void GoToNextPlayer() 
        {
            
            
                AddCreatedWordsToPlayer();
            AddCreatedWordsToUnshuffledWords();
                ResetEnteredWords();
                this.CurrentPlayer=playerOrder.GoToNextPlayer();
                numberOfPlayersEnteredWords++;
            if (numberOfPlayersEnteredWords == numberOfPlayersInGame)
            {
                StartButtonVisible = true;
                NextPlayerButtonVisible = false;
            }

        }

        private void ResetEnteredWords()
        {
            this.EnteredWords = InitializeEnteredWords(this.EnteredWords.Count);
        }

        public void AddCreatedWordsToPlayer() 
        {
            foreach (var enteredWord in this.EnteredWords)
            {
                this.CurrentPlayer.AddCreatedWord(enteredWord.Word);
            }
        }

        public void AddCreatedWordsToUnshuffledWords()
        {
            foreach (var enteredWord in this.EnteredWords)
            {
                this.UnshuffledWords.Add(enteredWord.Word);
            }
        }
    }
}
