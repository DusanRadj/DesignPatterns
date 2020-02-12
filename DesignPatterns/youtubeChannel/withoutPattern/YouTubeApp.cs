using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesignPatterns.youtubeChannel.observerPattern.model;

namespace DesignPatterns.youtubeChannel.withoutPattern
{
    class YouTubeApp
    {
        private static Dictionary<String, YouTubeChannel> channels = new Dictionary<String, YouTubeChannel>();

        public static Dictionary<String, YouTubeChannel> getYouTubeChannels()
        {
            return channels;
        }

        public YouTubeApp()
        {

        }

        public void createYouTubeChannel()
        {
            Console.WriteLine("Enter name for the channel: ");
            String name = Console.ReadLine();
            try
            {
                channels.Add(name, new YouTubeChannel(name));
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Channel with that name already exists!");
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
                YouTubeChannel subscriber = channels[yourName];
                try
                {
                    YouTubeChannel channel = channels[channelName];
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


        public void unsubscribeChannel()
        {
            Console.WriteLine("Enter your youtube channel name: ");
            String yourName = Console.ReadLine();
            Console.WriteLine("Enter youtube channel to unsubscribe: ");
            String channelName = Console.ReadLine();

            try
            {
                YouTubeChannel subscriber = channels[yourName];
                try
                {
                    YouTubeChannel channel = channels[channelName];
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


        public void createNewVideo()
        {
            Console.WriteLine("Enter youtube channel: ");
            String channelName = Console.ReadLine();
            try
            {
                YouTubeChannel channel = channels[channelName];
                channel.createNewVideo();
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Youtube channel name does not exist!");
            }
        }

        public void displayChannels()
        {
            foreach (KeyValuePair<String, YouTubeChannel> channel in channels)
            {
                Console.WriteLine(channel.Value.ToString());
            }
        }

        public void viewYouTubeChannelNotifications()
        {
            Console.WriteLine("Enter youtube channel name: ");
            String channelName = Console.ReadLine();

            try
            {
                YouTubeChannel channel = channels[channelName];
                channel.displayNotifications();
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Youtube channel name does not exist!");
            }
        }


        public void clearYouTubeChannelNotifications()
        {
            Console.WriteLine("Enter youtube channel name: ");
            String channelName = Console.ReadLine();

            try
            {
                YouTubeChannel channel = channels[channelName];
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
            Console.WriteLine("2. Create video for youtube channel                      ");
            Console.WriteLine("3. Display all channels                                  ");
            Console.WriteLine("4. Subscribe channel                                     ");
            Console.WriteLine("5. Unsubscribe channel                                   ");
            Console.WriteLine("6. View youtube channel notifications                    ");
            Console.WriteLine("7. Clear youtube channel notifications                  ");
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
                    this.createNewVideo();
                    break;
                case 3:
                    this.displayChannels();
                    break;
                case 4:
                    this.subscribeChannel();
                    break;
                case 5:
                    this.unsubscribeChannel();
                    break;
                case 6:
                    this.viewYouTubeChannelNotifications();
                    break;
                case 7:
                    this.clearYouTubeChannelNotifications();
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
