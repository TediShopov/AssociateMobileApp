﻿using Associate.Models;
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
    public partial class PlayGamePage : ContentPage
    {
        public PlayGameViewModel playGameViewModel { get; set; }
        public PlayGamePage(Game game)
        {
            this.playGameViewModel = new PlayGameViewModel(game);
            BindingContext = this.playGameViewModel;
            InitializeComponent();
        }
    }
}