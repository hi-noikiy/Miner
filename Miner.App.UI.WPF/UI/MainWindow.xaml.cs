﻿using System;
using System.Windows;
using System.Windows.Threading;
using System.ComponentModel;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace HD
{
  public partial class MainWindow : MetroWindow
  {
    #region Data
    public static MainWindow instance;
    #endregion

    #region Init
    public MainWindow()
    {
      instance = this;
      InitializeComponent();
      mainWindow.DataContext = new MainViewModel();
    }

    void OnWindowClosing(
      object sender,
      CancelEventArgs e)
    {
      Miner.instance.settings.SaveOnExit();
      Stop();
    }
    #endregion

    #region Events
    void OnStartStopButtonClick(
      object sender,
      RoutedEventArgs e)
    {
      if (Miner.instance.isMinerRunning)
      {
        Stop();
      }
      else
      {
        Start(true);
      }
    }
    #endregion

    #region Helpers
    void Start(
      bool wasManuallyStarted)
    {
      Miner.instance.Start(wasManuallyStarted);
    }

    void Stop()
    {
      Miner.instance.Stop();
    }

    void mainWindow_StateChanged(
      object sender,
      EventArgs e)
    {
      if (mainWindow.WindowState == WindowState.Minimized)
      {
        // TODO hide once our tray icon is working
        //mainWindow.Visibility = Visibility.Hidden;
      }
    }
    #endregion

    async void reportBug(object sender, RoutedEventArgs e)
    {
      await mainWindow.ShowMessageAsync("ERROR!", "There are no bugs...");
    }

    void miningforTile_Click(object sender, RoutedEventArgs e)
    {
    }

    void sliderPercentToHD_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
    }

    void mainWindow_Loaded(object sender, RoutedEventArgs e)
    {
    }

    void Settings_Click(
      object sender, 
      RoutedEventArgs e)
    {
      SettingsWindow settings = new SettingsWindow(((MainViewModel)DataContext).settings);
      settings.ShowDialog();
    }
  }
}
