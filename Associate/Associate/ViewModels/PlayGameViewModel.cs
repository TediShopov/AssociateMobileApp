using Associate.Models;
using Associate.Models.Interfaces;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Reflection;
using System.Linq;

namespace Associate.ViewModels
{
    public class PlayGameViewModel : INotifyPropertyChanged
    {


        public event PropertyChangedEventHandler PropertyChanged;
        public PlayGameViewModel(Game game)
        {
            //setting up game
            this.Game = game;
            this.Game.GoToNextStage();
            SetUpNextPlayerRound();

            //Command init
            this.GoToNextRoundCommand = new Command(GoToNextRound);
            this.GoToNextStageCommand = new Command(GoToNextStage);
            this.StartRoundTimerCommand = new Command(StartRoundTimer);
            this.GuessWordCommand = new Command(GuessWord);


            //Butttons and Labels Init
            this.WordsGuessedThisRound = 0;
            this.CurrentPlayerName = this.Game.CurrentStage.CurrentRound.CurrentPlayer.Name;
            this.DisplayTimeRemainingString = this.Game.CurrentStage.CurrentRound.RoundTimer.TimeLeft.ToString();
            this.StartRoundTimerButtonVisible = true;
            this.NextStageButtonVisible = false;
            this.NextRoundButtonVisible = false;
            this.EndGameButtonVisible = false;



        }

        private void SetUpNextPlayerRound()
        {
            this.Game.CurrentStage.SetUpPlayerRound();
            //Timer Settings- On Tick and On Stop
            this.Game.CurrentStage.CurrentRound.RoundTimer.OnEachTick = OnEachSecond;
            this.Game.CurrentStage.CurrentRound.RoundTimer.OnTimerStoped = OnTimerRanOut;
        }

        public Game Game { get; set; }

        public int WordsGuessedThisRound { get; set; }

        public string DisplayTimeRemainingString { get; set; }

        public string CurrentPlayerName { get; set; }

        public string WordToGuess { get; set; }
        public bool StartRoundTimerButtonVisible { get; set; }
        public bool EndGameButtonVisible { get; set; }
        public bool NextStageButtonVisible { get; set; }

        public bool NextRoundButtonVisible { get; set; }
        public ICommand GoToNextRoundCommand { get; set; }

        public ICommand GoToNextStageCommand { get; set; }
        public ICommand StartRoundTimerCommand { get; set; }

        public ICommand GuessWordCommand { get; set; }

        public void GoToNextStage()
        {
            this.Game.GoToNextStage();
            SetUpNextPlayerRound();
            this.CurrentPlayerName = this.Game.CurrentStage.CurrentRound.CurrentPlayer.Name;
            this.DisplayTimeRemainingString = this.Game.CurrentStage.CurrentRound.RoundTimer.TimeLeft.ToString();
            MakeButtonsIsVisiblePropertyTrueByName("StartRoundTimer");
        }

        public void GoToNextRound()
        {
           
            SetUpNextPlayerRound();
            this.CurrentPlayerName = this.Game.CurrentStage.CurrentRound.CurrentPlayer.Name;
            this.DisplayTimeRemainingString = this.Game.CurrentStage.CurrentRound.RoundTimer.TimeLeft.ToString();
            MakeButtonsIsVisiblePropertyTrueByName("StartRoundTimer");
        }
        public void GuessWord()
        {
            this.Game.CurrentStage.GuessWordForCurrentPlayer();
            this.WordsGuessedThisRound++;
            if (this.Game.CurrentStage.IsOver)
            {
                OnStageOver();
            }
            else
            {
                this.WordToGuess = this.Game.CurrentStage.GiveOutNewWordToGuess();
            }
        }

        public void StartRoundTimer()
        {
            this.Game.CurrentStage.CurrentRound.RoundTimer.StartTimer();
            this.WordToGuess = this.Game.CurrentStage.GiveOutNewWordToGuess();
            //ТОДО
        }

        public void StopRoundTimer()
        {
            this.Game.CurrentStage.CurrentRound.RoundTimer.StopTimer();
        }

        private void OnStageOver()
        {
            if (this.Game.OnLastStage)
            {
                MakeButtonsIsVisiblePropertyTrueByName("EndGame");
            }
            else
            {
                MakeButtonsIsVisiblePropertyTrueByName("NextStage");
            }

        }

        public void StartTimer()
        {
            this.Game.CurrentStage.CurrentRound.RoundTimer.StartTimer();
        }

        public void OnTimerRanOut()
        {
            MakeButtonsIsVisiblePropertyTrueByName("NextRound");
        }

        public void OnEachSecond()
        {
            this.DisplayTimeRemainingString = this.Game.CurrentStage.CurrentRound.RoundTimer.TimeLeft.ToString();
        }

        private void MakeButtonsIsVisiblePropertyTrueByName(params string[] propertyNames) 
        {
            var propertyInfos = typeof(PlayGameViewModel).GetProperties(BindingFlags.Public | BindingFlags.Instance)
               .Where(x=>x.Name.EndsWith("ButtonVisible") && x.PropertyType==typeof(bool))
               .ToList()
                ;

            foreach (var propertyInfo in propertyInfos)
            {
                propertyInfo.SetValue(this, false);
            }
            foreach (var propertyName in propertyNames)
            {
                var propertyNameWithSuffix = propertyName + "ButtonVisible";
                propertyInfos.FirstOrDefault(x => x.Name == propertyNameWithSuffix).SetValue(this, true);
            }
           
        }

        

        
    }
}
