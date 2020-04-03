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

        public PatternApp() { }

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
                            MusicPlayerApp.getInstance().startApp();
                            break;
                        }
                    case "2":
                        {
                            YouTubeApp.getInstance().startApp();
                            break;
                        }
                    case "3":
                        {
                            GoogleAccountApp.getInstance().startApp();
                            break;
                        }
                    default:
                        {
                            PizzaOrderApp.getInstance().startApp();
                            break;
                        }
                }
                
            }

        }
    }
}
