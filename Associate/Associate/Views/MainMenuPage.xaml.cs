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
    public partial class MainMenuPage : ContentPage
    {
        public MainMenuPage()
        {
            InitializeComponent();
          
          

        }

        private async void OnPlayButtonClicked(object sender, EventArgs e)
        {
           await this.Navigation.PushAsync(new CreateTeamsPage());
        }
    }
}