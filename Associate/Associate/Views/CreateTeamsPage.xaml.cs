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
            ViewModelLocator.GameCreationViewModel.CreateTeams();
            await this.Navigation.PushAsync(new StageConfigurationPage());
        }
    }
}