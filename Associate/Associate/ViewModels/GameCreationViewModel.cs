using Associate.Models;
using Associate.Models.Interfaces;
using Syncfusion.DataSource.Extensions;
using Syncfusion.XForms.Pickers;
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

       
        public  class StageDetails : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            public StageDetails(string name, TimeSpan timePerPlayer,int skipsPerRound=0)
            {
                this.Name = name;
                this.TimePerPlayer = timePerPlayer;
                this.SkipsPerRound = skipsPerRound;
            }

            

            public int SkipsPerRound { get; set; }
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

            this.Teams = new ObservableCollection<ITeam>();
            this.StagesDetails = new ObservableCollection<StageDetails>();

            #region Adding test Teams



            var teamOne = new Team("TeamOne");
            teamOne.Members.Add(new Player("Gosho"));
            teamOne.Members.Add(new Player("Pesho"));

            var teamTwo = new Team("TeamTwo");
            teamTwo.Members.Add(new Player("Ivan"));
            teamTwo.Members.Add(new Player("Ivanica"));

            Teams.Add(teamOne);
            Teams.Add(teamTwo);
            #endregion


            this.AddTeam = new Command(AddTeamToCollection);
           
            this.AddStageDetailCom = new Command<string>(AddStageDetailWithName);
            this.InitializePlayerOrderCom = new Command(InitializePlayerOrder);


           

            #region Populating Winconditons
            this.WinningConditions = new List<WinningConditionWithName>();
            this.WinningConditions.Add(new WinningConditionWithName(new MostWordsGuessedWinningCondition()));
            this.WinningConditions.Add(new WinningConditionWithName("Different Points Each Stage", new PredeterminedPointsPerStageWinningCondition()));
            #endregion

        }

    
        public IPlayerOrder PlayerOrder { get; set; }

        public StageDetails StageDetailTarget { get; set; }

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
            teamOne.Members.Add(new Player("PlayerOne"));
            teamOne.Members.Add(new Player("PlayerTwo"));
            this.Teams.Add(teamOne);
            
        }

        public void AddStageDetailWithName(string stageName)
        {
            this.StagesDetails.Add(new StageDetails(stageName, new TimeSpan(0, 0, 1)));            
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
                stage.SkipsPerRound = stageDetails.SkipsPerRound;
                listOfGameStage.Add(stage);
            }
            return listOfGameStage;
        }

        public void CreateTeams()
        {

            var teamList = new List<ITeam>();
                foreach (var team in this.Teams)
                {
                    var teamToAdd = new Team(team.Name);
                    foreach (var member in team.Members)
                    {
                        teamToAdd.Members.Add(new Player(member.Name));
                    }
                    teamList.Add(teamToAdd);
                }
                this.gameTeams = new List<ITeam>(teamList);

          


        }

        public List<string> GetRepeatingTeamNamesIfAny()
        {
           
            
            var repeatingTeamNames = this.Teams.GroupBy(x => x.Name)
                 .Where(g => g.Count() > 1)
                 .Select(y => y.Key)
                 .ToList();

            return repeatingTeamNames;


        }


        public List<string> GetRepeatingPlayerNamesIfAny()
        {
            var repeatingPlayerNames = this.Teams.SelectMany(x => x.Members)
                .GroupBy(x => x.Name)
            .Where(g => g.Count() > 1)
            .Select(y => y.Key)
            .ToList()
            ;
           return repeatingPlayerNames;
        }

        public ICommand AddTeam { get; set; }
        public ICommand AddStageDetailCom { get; set; }

        public ICommand InitializePlayerOrderCom { get; set; }


        
    }
}
