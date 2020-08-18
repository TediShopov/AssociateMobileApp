using Associate.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Associate.Services
{
    public static class ViewModelLocator
    {
        private static GameCreationViewModel _gameCreationViewModel = new GameCreationViewModel();
        public static GameCreationViewModel GameCreationViewModel
        {
            get
            {
                return _gameCreationViewModel;
            }
        }
    }
}
