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
