using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesignPatterns.musicPlayer.statePattern;
using DesignPatterns.googleAccount.pattern;
using DesignPatterns.youtubeChannel.observerPattern;
using DesignPatterns.pizzaOrder.pattern;

namespace DesignPatterns
{
    class PatternApp
    {
        private MusicPlayerApp musicPlayerApp;
        private GoogleAccountApp googleAccountApp;
        private YouTubeApp youTubeApp;
        private PizzaOrderApp pizzaOrderApp;

        public PatternApp()
        {
            this.musicPlayerApp = MusicPlayerApp.getInstance();
            this.googleAccountApp = GoogleAccountApp.getInstance();
            this.youTubeApp = YouTubeApp.getInstance();
            this.pizzaOrderApp = PizzaOrderApp.getInstance();
            
        }

        public void menu()
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose example to run: ");
                Console.WriteLine("1. Music player");
                Console.WriteLine("2. YouTube");
                Console.WriteLine("3. Google account");
                Console.WriteLine("4. Pizza ordering");
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
                    case "3":
                        {
                            this.googleAccountApp.startApp();
                            break;
                        }
                    default:
                        this.pizzaOrderApp.startApp();
                        break;
                }
                

                
            }

        }
    }
}
