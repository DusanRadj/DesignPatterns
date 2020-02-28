using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesignPatterns.musicPlayer.withoutPattern;
using DesignPatterns.googleAccount.withoutPattern;
using DesignPatterns.youtubeChannel.withoutPattern;
using DesignPatterns.pizzaOrder.withoutPattern;

namespace DesignPatterns
{
    class WithoutPatternApp
    {
        private MusicPlayerApp musicPlayerApp;
        private GoogleAccountApp googleAccountApp;
        private YouTubeApp youTubeApp;
        private PizzaOrderApp pizzaOrderApp;

        public WithoutPatternApp()
        {
            this.musicPlayerApp = new MusicPlayerApp();
            this.googleAccountApp = new GoogleAccountApp();
            this.youTubeApp = new YouTubeApp();
            this.pizzaOrderApp = new PizzaOrderApp();
        }

        public void menu()
        {
            while (true)
            {
                Console.WriteLine("Choose example to run: ");
                Console.WriteLine("1. Music player ");
                Console.WriteLine("2. YouTube ");
                Console.WriteLine("3. Google account");
                Console.WriteLine("4. Pizza order");
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
