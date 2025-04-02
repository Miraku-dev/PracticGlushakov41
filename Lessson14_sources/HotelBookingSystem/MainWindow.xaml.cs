﻿using System;
using System.Windows;
using HotelBookingSystem.ViewModels;

namespace HotelBookingSystem
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }

    }
}