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
        string name = Settings.GetStaticText();

        //Check to see if its a image or animtation
        bool isImage = false;

        //Path to the image/animation
        string path = System.IO.Path.Combine(Environment.CurrentDirectory, Settings.GetAssetSource());

        //Checks to see if we use the bluetooth device name or a custom static name
        bool staticText = false;

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
                anim.Source = new Uri(path, UriKind.RelativeOrAbsolute);
                anim.MediaEnded += Anim_MediaEnded;
                asset.Children.Add(anim);
                anim.LoadedBehavior = MediaState.Manual;
                anim.Play();
            }

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
        private void Button_Click(object sender, RoutedEventArgs e)
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
