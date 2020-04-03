using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesignPatterns.musicPlayer.statePattern;
using DesignPatterns.youtubeChannel.observerPattern;
using DesignPatterns.musicPlayer.statePattern.model;

namespace DesignPatterns
{
    class Program
    {
        public static void Menu()
        {
            /*Song s = new Song("River", "Eminem Feat. Ed Sheeran", 216, "River.mp3");
            NAudio.Wave.WaveStream a = NAudio.Wave.WaveFormatConversionStream.CreatePcmStream(new NAudio.Wave.Mp3FileReader(s.Path));
            NAudio.Wave.BlockAlignReductionStream stream = new NAudio.Wave.BlockAlignReductionStream(a);
            NAudio.Wave.DirectSoundOut output = new NAudio.Wave.DirectSoundOut();
            output.Init(stream);
            output.Play();
            */

            while (true)
            {
                Console.WriteLine("Choose way to run: ");
                Console.WriteLine("1. Pattern");
                Console.WriteLine("2. Without Pattern");
                String option = Console.ReadLine();

                Console.Clear();

                if (option == "1")
                {
                    PatternApp app = new PatternApp();
                    app.menu();
                }
                else
                {
                    WithoutPatternApp app = new WithoutPatternApp();
                    app.menu();
                }
            }
            
        }

        


        static void Main(string[] args)
        {
            
            
            Menu();   
        }
    }
}
