using Associate.Services;
using Syncfusion.XForms.Pickers;
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
    public partial class StageConfigurationPage : ContentPage
    {

        private Button selectedButton=null;
        private string TimeToChange = null;
        public StageConfigurationPage()
        {
            ViewModelLocator.GameCreationViewModel.InitializeDefaultStage();
            BindingContext = ViewModelLocator.GameCreationViewModel;
            InitializeComponent();
          //  this.timePicker.OkCommand = ViewModelLocator.GameCreationViewModel.ChangeStageDetailsTimeCom.Execute(this.timePicker.);
        }

       

        private void OpenTimerButton_Clicked(object sender, EventArgs e)        
        {
            this.selectedButton=(Button)sender;
            this.timePicker.IsOpen = true;
          //  ViewModelLocator.GameCreationViewModel.ChangeTargetStageForChangingTimePerPlayerCom.Execute(selectedButton.CommandParameter);
            this.timePicker.TimeSelected += TimePicker_TimeSelected;
        }

        private void TimePicker_TimeSelected(object sender, TimeChangedEventArgs e)
        {
            var b = sender;
            var a = e.NewValue;
            this.TimeToChange = e.NewValue.ToString();


        }

        private async void  GoToChooseWinningConditionButon_Clicked(object sender, EventArgs e)
        {
            var a = ViewModelLocator.GameCreationViewModel;
            await this.Navigation.PushAsync(new WordEnterAndWinningConditionOptionsPage());
        }

        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            this.timePicker.IsOpen = false;
        }

        private void SetButton_Clicked(object sender, EventArgs e)
        {
            this.selectedButton.Text = this.TimeToChange;
        }
    }
}