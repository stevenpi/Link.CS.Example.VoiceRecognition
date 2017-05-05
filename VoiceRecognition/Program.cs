using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;

namespace VoiceRecognition
{
    class Program
    {
        static void Main(string[] args)
        {
            var speechManager = new SpeechManager();
            speechManager.CommandRecognized += PrintCommand;
            while (true)
            {
                Console.ReadKey();
            }
        }

        private static void PrintCommand(object sender, SpeechRecognizedEventArgs args)
        {
            Console.WriteLine(args.Result.Text);
        }
    }
}
