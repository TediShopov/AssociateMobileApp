using Associate.Models;
using Associate.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Associate.ViewModels
{
   public  class ResultPageViewModel:INotifyPropertyChanged
    {
        private readonly Game game;

        public event PropertyChangedEventHandler PropertyChanged;
        public ResultPageViewModel(Game game)
        {
            this.game = game;
            this.OrderedTeamsByPoints = OrderTeamsByPoints();
        }

        private Dictionary<ITeam,int> OrderTeamsByPoints()
        {
            var dictionaryOfTeamAndPoints = new Dictionary<ITeam,int>();
            foreach (var team in this.game.Teams)
            {
               int teamPoints= this.game.WinningCondition.TotalPointsForTeam(team);
                dictionaryOfTeamAndPoints.Add(team, teamPoints);

            }
            return dictionaryOfTeamAndPoints;
        }

        public ITeam  TeamWinner { get { return this.game.WinningCondition.GetWinner(); } }
        public Dictionary<ITeam,int> OrderedTeamsByPoints {
            get;set;
        }
    }
}
