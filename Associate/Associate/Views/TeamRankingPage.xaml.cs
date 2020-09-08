using Associate.Models;
using Associate.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Associate.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class TeamRankingPage : ContentPage
    {
        public TeamRankingPage(Game game)
        {
            this.BindingContext = new ResultPageViewModel(game);
            InitializeComponent();
        }
    }
}