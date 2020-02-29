using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BluetoothUI
{
    /// <summary>
    /// Interaction logic for MainUI.xaml
    /// </summary>
    public partial class LightUI : Window
    {
        //Fade in delay in (ms)
        int waitDelay = 1;

        //Name of the AirPods
        string name = Settings.GetDeviceName();

        //Path to the image/animation
        string path = System.IO.Path.Combine(Environment.CurrentDirectory, Settings.GetAssetSource());

        //Self explanitory
        string buttonText = Settings.GetButtonText();

        //Initializing the animation/image
        MediaElement anim;
        Image image;

        public LightUI()
        {
            InitializeComponent();

            //Set the gray background parameters
            this.Height = SystemParameters.WorkArea.Height;
            this.Width = SystemParameters.WorkArea.Width;

            //Check to see if the template is using a image or not to init the proper variables
            if (Settings.CheckIfUsingImage())
            {
                image = new Image();
                image.Source = new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));
                image.Width = 285;
                image.Height = 135;
                asset.Children.Add(image);
            }
            else
            {
                anim = new MediaElement();
                anim.Width = 285;
                anim.Height = 135;
                anim.Source = new Uri(path, UriKind.RelativeOrAbsolute);
                anim.MediaEnded += Anim_MediaEnded;
                asset.Children.Add(anim);
                anim.LoadedBehavior = MediaState.Manual;
                anim.Play();
            }

            if (Settings.CheckIfUsingStaticText())
                deviceName.Content = Settings.GetStaticText();
            else
                deviceName.Content = Settings.GetDeviceName();

            this.doneButton.Content = buttonText;
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
            //Fade in
            FadeIn();
        }

        /// <summary>
        /// Same as <see cref="Window_MouseDown(object, MouseButtonEventArgs)"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //Fade out
            FadeOut();

            //Close
            this.Close();
        }

        /// <summary>
        /// Loops the animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Anim_MediaEnded(object sender, RoutedEventArgs e)
        {
            
            anim.Position = new TimeSpan(0, 0, 0);
            anim.Play();
        }

        private async void FadeIn()
        {
            //Fades in
            for (double i = 0; i <= 1; i += 0.1)
            {
                this.Opacity = i;
                await Task.Delay(waitDelay);
            }
        }

        private async void FadeOut()
        {
            //Fades out
            for (double i = 1; i >= 0; i -= 0.1)
            {
                this.Opacity = i;
                await Task.Delay(10);
            }
        }
    }
}
