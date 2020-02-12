using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesignPatterns.youtubeChannel.observerPattern.model;
using DesignPatterns.youtubeChannel.observerPattern;

namespace DesignPatterns.googleAccount.pattern
{
    class GoogleAccountApp
    {
        private Dictionary<String, GoogleAccount> googleAccounts;
        private static GoogleAccountApp instance;

        private GoogleAccountApp()
        {
            this.googleAccounts = new Dictionary<String, GoogleAccount>();
        }

        public static GoogleAccountApp getInstance()
        {
            if (instance == null)
            {
                instance = new GoogleAccountApp();
            }

            return instance;
        }

        public void createGoogleAccount()
        {
            Console.WriteLine("Enter username for account: ");
            String username = Console.ReadLine();
            try
            {
                this.googleAccounts.Add(username, new GoogleAccount(username));
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Google account with that name already exists!");
            }

        }

        public void subscribeAccount(Dictionary<String,YouTubeChannel> channels)
        {
            Console.WriteLine("Enter your google account username: ");
            String username = Console.ReadLine();
            Console.WriteLine("Enter youtube channel to subscribe: ");
            String channelName = Console.ReadLine();

            try
            {
                GoogleAccount googleAccount = this.googleAccounts[username];
                try
                {
                    YouTubeChannel channel = channels[channelName];
                    googleAccount.subscribe(channel);
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("Youtube channel name you want to subscribe does not exist!");
                }

            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Your google account name is incorrect!");
            }
        }


        public void unsubscribeAccount(Dictionary<String, YouTubeChannel> channels)
        {
            Console.WriteLine("Enter your google account username: ");
            String username = Console.ReadLine();
            Console.WriteLine("Enter youtube channel to unsubscribe: ");
            String channelName = Console.ReadLine();

            try
            {
                GoogleAccount googleAccount = this.googleAccounts[username];
                try
                {
                    YouTubeChannel channel = channels[channelName];
                    googleAccount.unsubscribe(channel);
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("Youtube channel name you want to unsubscribe does not exist!");
                }

            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Your google account name is incorrect!");
            }
        }

        public void displayAccounts()
        {
            foreach (KeyValuePair<String, GoogleAccount> account in googleAccounts)
            {
                Console.WriteLine(account.Value.ToString());
            }
        }

        public void viewGoogleAccountMails()
        {
            Console.WriteLine("Enter google account username: ");
            String accountName = Console.ReadLine();

            try
            {
                GoogleAccount googleAccount = this.googleAccounts[accountName];
                googleAccount.displayAllMails();
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Google account name does not exist!");
            }
        }


        public void displayMenu()
        {
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("Options:                                                 ");
            Console.WriteLine("1. Create Google account                                 ");
            Console.WriteLine("2. Display all              google accounts              ");
            Console.WriteLine("3. Subscribe google account                              ");
            Console.WriteLine("4. Unsubscribe google account                            ");
            Console.WriteLine("5. View google account emails                            ");
            Console.WriteLine("0. Exit                                                  ");
            Console.WriteLine("---------------------------------------------------------");
        }

        public int callAction()
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
                    this.createGoogleAccount();
                    break;
                case 2:
                    this.displayAccounts();
                    break;
                case 3:
                    this.subscribeAccount(YouTubeApp.getInstance().Channels);
                    break;
                case 4:
                    this.unsubscribeAccount(YouTubeApp.getInstance().Channels);
                    break;
                case 5:
                    this.viewGoogleAccountMails();
                    break;
                case 0:
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
