using Associate.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Associate.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateTeamsPage : ContentPage
    {
        
        public CreateTeamsPage()
        {
            InitializeComponent();
            BindingContext = ViewModelLocator.GameCreationViewModel;
        }

        private async void  StageConfigurationButton_Clicked(object sender, EventArgs e)
        {

             var repeatingTeamNames=ViewModelLocator.GameCreationViewModel.GetRepeatingTeamNamesIfAny();
            var repeatingPlayerNames= ViewModelLocator.GameCreationViewModel.GetRepeatingPlayerNamesIfAny();
            if (repeatingPlayerNames.Count==0 && repeatingTeamNames.Count==0)
            {
                ViewModelLocator.GameCreationViewModel.CreateTeams();
                await this.Navigation.PushAsync(new InitializePlayerOrderPage());
            }
            else
            {
                foreach (var collectionView in this.Accordion.Children)
                {
                    var col = (CollectionView)collectionView;
                    
                    var row = collectionView.Parent;
                }
            }
        }
    }
}