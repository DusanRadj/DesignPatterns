using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesignPatterns.youtubeChannel.observerPattern.model;

namespace DesignPatterns.youtubeChannel.withoutPattern
{
    class YouTubeApp
    {
        private Dictionary<String, YouTubeChannel> channels;
        private Dictionary<String, GoogleAccount> googleAccounts;
        
        public YouTubeApp()
        {
            this.channels = new Dictionary<String, YouTubeChannel>();
            this.googleAccounts = new Dictionary<String, GoogleAccount>();
        }

        public void createYouTubeChannel()
        {
            Console.WriteLine("Enter name for the channel: ");
            String name = Console.ReadLine();
            try
            {
                this.channels.Add(name, new YouTubeChannel(name));
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Channel with that name already exists!");
            }
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

        public void subscribeChannel()
        {
            Console.WriteLine("Enter your youtube channel name: ");
            String yourName = Console.ReadLine();
            Console.WriteLine("Enter youtube channel to subscribe: ");
            String channelName = Console.ReadLine();

            try
            {
                YouTubeChannel subscriber = this.channels[yourName];
                try
                {
                    YouTubeChannel channel = this.channels[channelName];
                    subscriber.subscribe(channel);
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("Youtube channel name you want to subscribe does not exist!");
                }

            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Your youtube channel name is incorrect!");
            }
        }

        public void subscribeAccount()
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
                    YouTubeChannel channel = this.channels[channelName];
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

        public void unsubscribeChannel()
        {
            Console.WriteLine("Enter your youtube channel name: ");
            String yourName = Console.ReadLine();
            Console.WriteLine("Enter youtube channel to unsubscribe: ");
            String channelName = Console.ReadLine();

            try
            {
                YouTubeChannel subscriber = this.channels[yourName];
                try
                {
                    YouTubeChannel channel = this.channels[channelName];
                    subscriber.unsubscribe(channel);
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("Youtube channel name you want to unsubscribe does not exist!");
                }

            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Your youtube channel name is incorrect!");
            }
        }

        public void unsubscribeAccount()
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
                    YouTubeChannel channel = this.channels[channelName];
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

        public void createNewVideo()
        {
            Console.WriteLine("Enter youtube channel: ");
            String channelName = Console.ReadLine();
            try
            {
                YouTubeChannel channel = this.channels[channelName];
                channel.createNewVideo();
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Youtube channel name does not exist!");
            }
        }

        public void displayChannelsAndAccounts()
        {
            foreach (KeyValuePair<String, YouTubeChannel> channel in channels)
            {
                Console.WriteLine(channel.Value.ToString());
            }
            foreach (KeyValuePair<String, GoogleAccount> account in googleAccounts)
            {
                Console.WriteLine(account.Value.ToString());
            }
        }

        public void viewYouTubeChannelNotifications()
        {
            Console.WriteLine("Enter youtube channel name: ");
            String channelName = Console.ReadLine();

            try
            {
                YouTubeChannel channel = this.channels[channelName];
                channel.displayNotifications();
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Youtube channel name does not exist!");
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

        public void clearYouTubeChannelNotifications()
        {
            Console.WriteLine("Enter youtube channel name: ");
            String channelName = Console.ReadLine();

            try
            {
                YouTubeChannel channel = this.channels[channelName];
                channel.clearNotifications();
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Youtube channel name does not exist!");
            }
        }

        public void displayMenu()
        {
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("Options:                                                 ");
            Console.WriteLine("1. Create YouTube channel                                ");
            Console.WriteLine("2. Create Google account                                 ");
            Console.WriteLine("3. Create video for youtube channel                      ");
            Console.WriteLine("4. Display all channels and google accounts              ");
            Console.WriteLine("5. Subscribe channel                                     ");
            Console.WriteLine("6. Unsubscribe channel                                   ");
            Console.WriteLine("7. Subscribe google account                              ");
            Console.WriteLine("8. Unsubscribe google account                            ");
            Console.WriteLine("9. View youtube channel notifications                    ");
            Console.WriteLine("10. Clear youtube channel notifications                  ");
            Console.WriteLine("11. View google account emails                           ");
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
                    this.createYouTubeChannel();
                    break;
                case 2:
                    this.createGoogleAccount();
                    break;
                case 3:
                    this.createNewVideo();
                    break;
                case 4:
                    this.displayChannelsAndAccounts();
                    break;
                case 5:
                    this.subscribeChannel();
                    break;
                case 6:
                    this.unsubscribeChannel();
                    break;
                case 7:
                    this.subscribeAccount();
                    break;
                case 8:
                    this.unsubscribeAccount();
                    break;
                case 9:
                    this.viewYouTubeChannelNotifications();
                    break;
                case 10:
                    this.clearYouTubeChannelNotifications();
                    break;
                case 11:
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
