using Associate.Services;
using Associate.ViewModels;
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
    public partial class WordEnterPage : ContentPage
    {
        public WordEnterViewModel wordEnterViewModel { get; set; }
        public WordEnterPage()
        {
            this.wordEnterViewModel= new WordEnterViewModel(ViewModelLocator.GameCreationViewModel.PlayerOrder, ViewModelLocator.GameCreationViewModel.WordsToCreatePerPlayer);
            BindingContext = this.wordEnterViewModel;
            InitializeComponent();
        }

        private void StartGameButton_Clicked(object sender, EventArgs e)
        {
            this.wordEnterViewModel.AddCreatedWordsToPlayer();
            this.wordEnterViewModel.AddCreatedWordsToUnshuffledWords();
            var game = ViewModelLocator.GameCreationViewModel.CreateGame(this.wordEnterViewModel.UnshuffledWords);
            this.Navigation.PushAsync(new PlayGamePage(game));
        }
    }
}