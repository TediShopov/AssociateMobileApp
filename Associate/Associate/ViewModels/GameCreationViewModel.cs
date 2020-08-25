using Associate.Models;
using Associate.Models.Interfaces;
using Syncfusion.DataSource.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Associate.ViewModels
{
   public class GameCreationViewModel:INotifyPropertyChanged
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

        private List<ITeam> gameTeams;


        public GameCreationViewModel()
        {
            
            this.AddTeam = new Command(AddTeamToCollection);
            this.InitializePlayerOrderCom = new Command(InitializePlayerOrder);

            this.Teams = new ObservableCollection<ITeam>();
            var teamOne = new Team("TeamOne");
            teamOne.Members.Add(new Player("Gosho"));
            teamOne.Members.Add(new Player("Pesho"));

            var teamTwo = new Team("TeamTwo");
            teamTwo.Members.Add(new Player("Ivan"));
            teamTwo.Members.Add(new Player("Ivanica"));

            Teams.Add(teamOne);
            Teams.Add(teamTwo);

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void InitializePlayerOrder() 
        {
            var teamList = new List<ITeam>(this.Teams);
            this.PlayerOrder = new PlayerOrder(teamList, false);
        }

        public void AddTeamToCollection() 
        {
            var a = this.Teams;
            var teamOne = new Team("TeamOne");
            teamOne.Members.Add(new Player("Gosho"));
            teamOne.Members.Add(new Player("Pesho"));
            this.Teams.Add(teamOne);
            
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
        public ICommand InitializePlayerOrderCom { get; set; }


        public IPlayerOrder PlayerOrder { get; set; }
        public ObservableCollection<ITeam> Teams { get; set; }
    }
}
