using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesignPatterns.musicPlayer.statePattern;
using DesignPatterns.youtubeChannel.observerPattern;

namespace DesignPatterns
{
    class Program
    {
        public static void Menu()
        {
            while (true)
            {
                Console.WriteLine("Choose example to run: ");
                Console.WriteLine("1. Music player (State Pattern)");
                Console.WriteLine("2. YouTube (Observer Pattern)");
                String option = Console.ReadLine();

                Console.Clear();

                if (option == "1")
                {
                    //MusicPlayerApp app = new MusicPlayerApp();
                    DesignPatterns.musicPlayer.withoutPattern.MusicPlayerApp app = new musicPlayer.withoutPattern.MusicPlayerApp();
                    app.startApp();
                }
                else
                {
                    //YouTubeApp app = new YouTubeApp();
                    DesignPatterns.youtubeChannel.withoutPattern.YouTubeApp app = new youtubeChannel.withoutPattern.YouTubeApp();
                    app.startApp();
                }
            }
            
        }

        


        static void Main(string[] args)
        {
            Menu();
            
        }
    }
}
