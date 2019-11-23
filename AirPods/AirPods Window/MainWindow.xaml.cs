using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace AirPods_Window
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Fade in delay
        int waitDelay = 1;

        //Name of the AirPods
        string name = "AirPods";

        //Type of AirPods
        int gen = (int)Generation.GenOne;

        public MainWindow()
        {
            //Gets the name of the AirPods from the registry. This name was set by the AirPods service, see the Service project.
            RegistryKey reg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AirPod Helper", true);
            if (reg != null)
            {
                name = reg.GetValue("name", "AirPods").ToString();
                int i = (int)reg.GetValue("generation", 1);
                if (i == (int)Generation.GenOne) gen = (int)Generation.GenOne;
                else if (i == (int)Generation.GenTwo) gen = (int)Generation.GenTwo;
                else if (i == (int)Generation.Pro) gen = (int)Generation.Pro;
            }

            InitializeComponent();

            //Sets the height and width of the grayish background
            this.Height = SystemParameters.WorkArea.Height;
            this.Width = SystemParameters.WorkArea.Width;

            //Changes the name of the label
            airpodName.Content = name;

            //Changes the window title
            this.Title = name;

            //Change video animation to appropiate animation
        }

        /// <summary>
        /// When the user clicks on the screen, the window closes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Fades out
            FadeOut();

            //Closes window
            this.Close();
        }

        /// <summary>
        /// Fades in and plays the animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Play the animation
            loop.LoadedBehavior = MediaState.Manual;
            loop.Play();

            //Fade in
            FadeIn();
        }

        /// <summary>
        /// Same as <see cref="Window_MouseDown(object, MouseButtonEventArgs)"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FadeOut();
            this.Close();
        }

        /// <summary>
        /// Loops the animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loop_MediaEnded(object sender, RoutedEventArgs e)
        {
            loop.Position = new TimeSpan(0, 0, 0);
            loop.Play();
        }

        private async void FadeIn()
        {
            //Fades in
            for (double i = 0; i <= 1; i += 0.1)
            {
                this.Opacity = i;
                mainBorder.Opacity = i;
                await Task.Delay(waitDelay);
            }
        }

        private async void FadeOut()
        {
            //Fades out
            for (double i = 1; i >= 0; i -= 0.1)
            {
                this.Opacity = i;
                mainBorder.Opacity = i;
                await Task.Delay(waitDelay);
            }
        }
    }

    public enum Generation
    {
        GenOne,
        GenTwo,
        Pro
    }
}
