using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Speech.Recognition;
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
using VoiceRecognition;

namespace Link.CS.Example.VoiceRecognition
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var speechManager = new SpeechManager();
            speechManager.CommandRecognized += HandleSpeechRecognized;
        }

        public void HandleSpeechRecognized(object sender, SpeechRecognizedEventArgs args)
        {
            var value = args.Result.Text;
            MainWindowSpeechLabel.Content = value;

            if (Properties.Resources.VoiceCommand_Stop == value)
            {
                ExitApplication();
            }
        }

        public void ExitApplication()
        {
            this.Close();
        }
    }
}
