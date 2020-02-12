using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesignPatterns.musicPlayer.withoutPattern;
using DesignPatterns.googleAccount.withoutPattern;
using DesignPatterns.youtubeChannel.withoutPattern;

namespace DesignPatterns
{
    class WithoutPatternApp
    {
        private MusicPlayerApp musicPlayerApp;
        private GoogleAccountApp googleAccountApp;
        private YouTubeApp youTubeApp;

        public WithoutPatternApp()
        {
            this.musicPlayerApp = new MusicPlayerApp();
            this.googleAccountApp = new GoogleAccountApp();
            this.youTubeApp = new YouTubeApp();
        }

        public void menu()
        {
            while (true)
            {
                Console.WriteLine("Choose example to run: ");
                Console.WriteLine("1. Music player ");
                Console.WriteLine("2. YouTube ");
                Console.WriteLine("3. Google account");
                String option = Console.ReadLine();

                Console.Clear();

                switch (option)
                {
                    case "1":
                        {
                            this.musicPlayerApp.startApp();
                            break;
                        }
                    case "2":
                        {
                            this.youTubeApp.startApp();
                            break;
                        }
                    default:
                        this.googleAccountApp.startApp();
                        break;
                }
            }
        }


    }
}
