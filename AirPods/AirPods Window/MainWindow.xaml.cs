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

        public MainWindow()
        {
            //Gets the name of the AirPods from the registry. This name was set by the AirPods service, see the Service project.
            RegistryKey reg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AirPod Helper", true);
            if (reg != null)
            {
                name = reg.GetValue("name", "AirPods").ToString();
            }

            InitializeComponent();

            //Sets the height and width of the grayish background
            this.Height = SystemParameters.WorkArea.Height;
            this.Width = SystemParameters.WorkArea.Width;

            //Changes the name of the label
            airpodName.Content = name;

            //Changes the window title
            this.Title = name;
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
            this.Opacity = 0.1;
            mainBorder.Opacity = 0.1;
            await Task.Delay(waitDelay);
            this.Opacity = 0.2;
            mainBorder.Opacity = 0.2;
            await Task.Delay(waitDelay);
            this.Opacity = 0.3;
            mainBorder.Opacity = 0.3;
            await Task.Delay(waitDelay);
            this.Opacity = 0.4;
            mainBorder.Opacity = 0.4;
            await Task.Delay(waitDelay);
            this.Opacity = 0.5;
            mainBorder.Opacity = 0.5;
            await Task.Delay(waitDelay);
            this.Opacity = 0.6;
            mainBorder.Opacity = 0.6;
            await Task.Delay(waitDelay);
            this.Opacity = 0.7;
            mainBorder.Opacity = 0.7;
            await Task.Delay(waitDelay);
            this.Opacity = 0.8;
            mainBorder.Opacity = 0.8;
            await Task.Delay(waitDelay);
            this.Opacity = 0.9;
            mainBorder.Opacity = 0.9;
            await Task.Delay(waitDelay);
            this.Opacity = 1;
            mainBorder.Opacity = 1;
        }

        private async void FadeOut()
        {
            //Fades out
            this.Opacity = 1;
            mainBorder.Opacity = 1;
            await Task.Delay(waitDelay);
            this.Opacity = 0.9;
            mainBorder.Opacity = 0.9;
            await Task.Delay(waitDelay);
            this.Opacity = 0.8;
            mainBorder.Opacity = 0.8;
            await Task.Delay(waitDelay);
            this.Opacity = 0.7;
            mainBorder.Opacity = 0.7;
            await Task.Delay(waitDelay);
            this.Opacity = 0.6;
            mainBorder.Opacity = 0.6;
            await Task.Delay(waitDelay);
            this.Opacity = 0.5;
            mainBorder.Opacity = 0.5;
            await Task.Delay(waitDelay);
            this.Opacity = 0.4;
            mainBorder.Opacity = 0.4;
            await Task.Delay(waitDelay);
            this.Opacity = 0.3;
            mainBorder.Opacity = 0.3;
            await Task.Delay(waitDelay);
            this.Opacity = 0.2;
            mainBorder.Opacity = 0.2;
            await Task.Delay(waitDelay);
            this.Opacity = 0.1;
            mainBorder.Opacity = 0.1;
            await Task.Delay(waitDelay);
            this.Opacity = 0;
            mainBorder.Opacity = 0;
        }
    }
}
