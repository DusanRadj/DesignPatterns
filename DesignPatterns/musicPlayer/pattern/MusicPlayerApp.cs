using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesignPatterns.musicPlayer.statePattern.model;

namespace DesignPatterns.musicPlayer.statePattern
{
    class MusicPlayerApp
    {
        private MusicPlayer musicPlayer;
        private static MusicPlayerApp instance;

        private MusicPlayerApp()
        {
            this.musicPlayer = new MusicPlayer();
            this.initializeMusicPlayerWithSongs();
        }

        private void initializeMusicPlayerWithSongs()
        {
            this.musicPlayer.Songs.Add(new Song("River", "Eminem Feat. Ed Sheeran", 216, "River.mp3"));
            this.musicPlayer.Songs.Add(new Song("Paint it black", "Roling Stones", 221, "Paint It, Black.mp3"));
            this.musicPlayer.Songs.Add(new Song("You'll never walk alone", "The Beatles", 163, "Ynwa.mp3"));
        }

        public static MusicPlayerApp getInstance()
        {
            if (instance == null)
            {
                instance = new MusicPlayerApp();
            }

            return instance;
        }

        private void displayMenu()
        {
            Console.WriteLine("---------------------------------------                              ");
            Console.WriteLine("Options:                                                             ");
            Console.WriteLine("1. Turn on                                                           ");
            Console.WriteLine("2. Play                                                              ");
            Console.WriteLine("3. Pause                                                             ");
            Console.WriteLine("4. Stop                                                              ");
            Console.WriteLine("5. Next                                                              ");
            Console.WriteLine("6. Previous                                                          ");
            Console.WriteLine("7. Lock/Unlock                                                       ");
            Console.WriteLine("8. Turn off                                                          ");
            Console.WriteLine("0. Exit                                                              ");
            Console.WriteLine("----------------------------------------                             ");
        }

        private int callAction()
        {
            int option = 0;
            Console.Write("Command: ");
            while (!Int32.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("----------------------------");
                Console.WriteLine("Invalid input, please enter a valid option (from 0 to 8)!");
                Console.WriteLine("----------------------------");
                Console.Write("Command: ");
            }

            switch (option)
            {
                case 1:
                    musicPlayer.turnOn();
                    break;
                case 2:
                    musicPlayer.play();
                    break;
                case 3:
                    musicPlayer.pause();
                    break;
                case 4:
                    musicPlayer.stop();
                    break;
                case 5:
                    musicPlayer.next();
                    break;
                case 6:
                    musicPlayer.previous();
                    break;
                case 7:
                    musicPlayer.lockUnlock();
                    break;
                case 8:
                    musicPlayer.turnOff();
                    break;
                case 0:
                    musicPlayer.turnOff();
                    Console.WriteLine("Exiting from music player app...");
                    break;
                default:
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Invalid input, please enter a valid option (from 0 to 8)!");
                    break;
            }
            Console.WriteLine("----------------------------");
            return option;
        }

        public void startApp()
        {
            int option;
            this.displayMenu();
            do
            {
                int leftPosition = Console.CursorLeft;
                int topPosition = Console.CursorTop;
                Console.SetCursorPosition(Console.WindowLeft, Console.WindowTop);
                this.displayMenu();
                Console.SetCursorPosition(leftPosition, topPosition);

                option = this.callAction();
            } while (option != 0);
        }

    }
}
