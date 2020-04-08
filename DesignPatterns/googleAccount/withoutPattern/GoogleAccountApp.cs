using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesignPatterns.youtubeChannel.withoutPattern;

namespace DesignPatterns.googleAccount.withoutPattern
{
    class GoogleAccountApp
    {
        private Dictionary<String, GoogleAccount> googleAccounts;

        public GoogleAccountApp()
        {
            this.googleAccounts = new Dictionary<String, GoogleAccount>();
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

        public void subscribeAccount(Dictionary<String, YouTubeChannel> channels)
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

        public void sendMail()
        {
            Console.Write("Enter your google account username: ");
            String senderName = Console.ReadLine();
            Console.Write("Enter reciever google account username: ");
            String recieverName = Console.ReadLine();

            try
            {
                GoogleAccount sender = this.googleAccounts[senderName];
                GoogleAccount reciever = this.googleAccounts[recieverName];
                sender.sendMail(reciever);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Google account names are invalid!");
            }
        }

        public void displayMenu()
        {
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("Options:                                                                 ");
            Console.WriteLine("1. Create Google account                                                 ");
            Console.WriteLine("2. Display all google accounts                                           ");
            Console.WriteLine("3. Subscribe google account                                              ");
            Console.WriteLine("4. Unsubscribe google account                                            ");
            Console.WriteLine("5. View google account emails                                            ");
            Console.WriteLine("6. Send email                                                            ");
            Console.WriteLine("0. Exit                                                                  ");
            Console.WriteLine("-------------------------------------------------------------------------");
        }

        public int callAction()
        {
            int option = 0;
            Console.Write("Command: ");
            while (!Int32.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("-------------------------------------------------------------------------");
                Console.WriteLine("Invalid input, please enter a valid option (from 0 to 6)!                ");
                Console.WriteLine("-------------------------------------------------------------------------");
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
                    this.subscribeAccount(YouTubeApp.Channels);
                    break;
                case 4:
                    this.unsubscribeAccount(YouTubeApp.Channels);
                    break;
                case 5:
                    this.viewGoogleAccountMails();
                    break;
                case 6:
                    this.sendMail();
                    break;
                case 0:
                    Console.WriteLine("Exiting from google account app...");
                    break;
                default:
                    Console.WriteLine("-------------------------------------------------------------------------");
                    Console.WriteLine("Invalid input, please enter a valid option (from 0 to 6)!                ");
                    break;
            }
            Console.WriteLine("-------------------------------------------------------------------------");
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
