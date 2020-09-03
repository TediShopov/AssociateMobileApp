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
    public partial class WordEnterAndWinningConditionOptionsPage : ContentPage
    {
        public WordEnterAndWinningConditionOptionsPage()
        {
            BindingContext = ViewModelLocator.GameCreationViewModel;
            InitializeComponent();
          
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var a = BindingContext = ViewModelLocator.GameCreationViewModel;
            this.Navigation.PushAsync(new WordEnterPage());
        }
    }
}