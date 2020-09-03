using Associate.Models;
using Associate.Models.Interfaces;
using Syncfusion.DataSource.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Associate.ViewModels
{
    public class GameCreationViewModel : INotifyPropertyChanged
    {

        //private class TeamViewModel :  INotifyPropertyChanged
        //{
        //    public event PropertyChangedEventHandler PropertyChanged;
        //    public List<IPlayer> Members { get; set ; }
        //    public string Name { get ; set ; }

        //}

        //private class PlayerViewModel :  INotifyPropertyChanged
        //{
        //    public event PropertyChangedEventHandler PropertyChanged;

        //    public string Name { get; set; }

        //}

        public class StageDetails : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            public StageDetails(string name, TimeSpan timePerPlayer)
            {
                this.Name = name;
                this.TimePerPlayer = timePerPlayer;
                this.SkippableWords = false;
            }

            

            public bool SkippableWords { get; set; }
            public string Name { get; set; }
            public TimeSpan TimePerPlayer { get; set; }
        }

        private List<ITeam> gameTeams;
        public class WinningConditionWithName
        {

            public WinningConditionWithName(string name, IWinningCondition winningCondition)
            {
                this.Name = name;
                this.WinningCondition = winningCondition;
            }

            public WinningConditionWithName(IWinningCondition winningCondition)
            {
                this.Name = winningCondition.GetType().Name;
                this.WinningCondition = winningCondition;
            }




            public string Name { get; set; }
            public IWinningCondition WinningCondition { get; set; }
        }






        public GameCreationViewModel()
        {

            this.AddTeam = new Command(AddTeamToCollection);
            this.AddStageDetailCom = new Command(AddStageDetail);
            this.InitializePlayerOrderCom = new Command(InitializePlayerOrder);

            this.Teams = new ObservableCollection<ITeam>();
            var teamOne = new Team("TeamOne");
            teamOne.Members.Add(new Player("Gosho"));
            teamOne.Members.Add(new Player("Pesho"));

            var teamTwo = new Team("TeamTwo");
            teamTwo.Members.Add(new Player("Ivan"));
            teamTwo.Members.Add(new Player("Ivanica"));



            this.StagesDetails = new ObservableCollection<StageDetails>();


            Teams.Add(teamOne);
            Teams.Add(teamTwo);

            this.WinningConditions = new List<WinningConditionWithName>();
            this.WinningConditions.Add(new WinningConditionWithName(new MostWordsGuessedWinningCondition()));
            this.WinningConditions.Add(new WinningConditionWithName("Different Points Each Stage", new PredeterminedPointsPerStageWinningCondition()));

        }

        public IPlayerOrder PlayerOrder { get; set; }

        public WinningConditionWithName SelectedWinnindCondition { get; set; }
        
        public IList<WinningConditionWithName> WinningConditions { get; set; }
        public ObservableCollection<ITeam> Teams { get; set; }

        public ObservableCollection<StageDetails> StagesDetails { get; set; }


        public int WordsToCreatePerPlayer { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void InitializePlayerOrder() 
        {
            var teamList = new List<ITeam>(this.Teams);
            this.PlayerOrder = new PlayerOrder(teamList, false);
        }

        public void InitializeDefaultStage() 
        {
            if (this.PlayerOrder!=null)
            {

                this.StagesDetails.Add(new StageDetails("Stage0",new TimeSpan(0,0,1)));

                //this.StagesDetails.Add(new StageDetails("Stage0","0:0:0"));
            }
        }

       

        public void AddTeamToCollection() 
        {
            var a = this.Teams;
            var teamOne = new Team("TeamOne");
            teamOne.Members.Add(new Player("Gosho"));
            teamOne.Members.Add(new Player("Pesho"));
            this.Teams.Add(teamOne);
            
        }

        public void AddStageDetail()
        {
            this.StagesDetails.Add(new StageDetails("Stage2", new TimeSpan(0, 0, 1)));
            
        }


        public Game CreateGame(List<string> unshuffledWords)
        {
            var game = new Game();
            game.Stages = CreateGameStagesFromGameStageDetails(unshuffledWords);
            game.Teams = new List<ITeam>(this.Teams);
            return game;
        }

        private List<IStage> CreateGameStagesFromGameStageDetails(List<string> unshuffledWords)
        {
            var listOfGameStage = new List<IStage>();
            foreach (var stageDetails in this.StagesDetails)
            {
                var stage = new Stage(unshuffledWords, this.PlayerOrder, stageDetails.TimePerPlayer);
            }
            return listOfGameStage;
        }

        public void CreateTeams() 
        {
            var teamList = new List<ITeam>();
            foreach (var team in this.Teams)
            {
                var teamToAdd=new Team(team.Name);
                foreach (var member in team.Members)
                {
                    teamToAdd.Members.Add(new Player(member.Name));
                }
                teamList.Add(teamToAdd);
            }
            this.gameTeams = new List<ITeam>(teamList);
        }

        public ICommand AddTeam { get; set; }
        public ICommand AddStageDetailCom { get; set; }


        public ICommand InitializePlayerOrderCom { get; set; }


        
    }
}
