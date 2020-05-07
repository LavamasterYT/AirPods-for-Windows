using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
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

namespace PopUpUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PopUpUI.Template template { get; set; }
        string deviceName { get; set; }
        MediaElement vid;

        public MainWindow(string template, string deviceName)
        {
            this.template = PopUpUI.Template.FromJson(File.ReadAllText(template));
            this.deviceName = this.template.UseDeviceName ? deviceName : this.template.DefaultDeviceName;

            if (this.template.AssetLocation.Contains("$docs$"))
                this.template.AssetLocation = this.template.AssetLocation.Replace("$docs$", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            if (this.template.AssetLocation.Contains("$root$"))
                this.template.AssetLocation = this.template.AssetLocation.Replace("$docs$", System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            Init();
        }

        private async void Init()
        {
            InitializeComponent();

            this.MouseDown += MainWindow_MouseDown;
            this.Background = FromHex(0, this.template.Tint);
            this.Height = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
            this.Left = 0;
            this.Top = 0;
            this.mainWindow.Background = FromHex(this.template.WindowBackground);
            this.devName.Foreground = FromHex(this.template.WindowForeground);
            this.devName.Content = this.deviceName;
            this.doneButton.Content = this.template.ButtonText;
            this.doneButton.Background = FromHex(this.template.ButtonBackground);
            this.doneButton.Foreground = FromHex(this.template.ButtonForeground);

            if (this.template.UsingImage)
            {
                var image = new ImageBrush();
                var image2 = new Image()
                {
                    Source = new BitmapImage(new Uri(this.template.AssetLocation, UriKind.RelativeOrAbsolute))
                };
                RenderOptions.SetBitmapScalingMode(image, BitmapScalingMode.HighQuality);
                image.ImageSource = image2.Source;
                media.Background = image;
            }
            else
            {
                vid = new MediaElement();
                vid.Source = new Uri(this.template.AssetLocation, UriKind.RelativeOrAbsolute);
                vid.Width = this.media.Width;
                vid.Height = this.media.Height;
                media.Children.Add(vid);
                vid.LoadedBehavior = MediaState.Manual;
                vid.Play();
                vid.MediaEnded += Vid_MediaEnded;
            }

            await Task.Delay(1000);

            FadeIn();
        }

        private void Vid_MediaEnded(object sender, RoutedEventArgs e)
        {
            if (this.template.LoopAnimation)
            {
                vid.Position = new TimeSpan(0, 0, 0);
                vid.Play();
            }
        }

        private async void MainWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            await FadeOut();
            this.Close();
        }

        private SolidColorBrush FromHex(byte a, string hex)
        {
            SolidColorBrush scb = new SolidColorBrush();
            scb.Color = Color.FromArgb(99, Convert.ToByte(hex.Substring(1, 2), 16), Convert.ToByte(hex.Substring(3, 2), 16), Convert.ToByte(hex.Substring(5, 2), 16));
            return scb;

        }

        private SolidColorBrush FromHex(string hex)
        {
            SolidColorBrush scb = new SolidColorBrush();
            scb.Color = Color.FromRgb(Convert.ToByte(hex.Substring(1, 2), 16), Convert.ToByte(hex.Substring(3, 2), 16), Convert.ToByte(hex.Substring(5, 2), 16));
            return scb;
        }

        private async void FadeIn()
        {
            for (double i = 0; i <= 1; i += 0.1)
            {
                this.Opacity = i;
                await Task.Delay(10);
            }
        }

        private async Task FadeOut()
        {
            for (double i = 1; i >= 0; i -= 0.1)
            {
                this.Opacity = i;
                await Task.Delay(10);
            }
        }

        private async void doneButton_Click(object sender, RoutedEventArgs e)
        {
            await FadeOut();
            this.Close();
        }
    }
}
