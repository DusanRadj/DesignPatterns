using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesignPatterns.youtubeChannel.observerPattern.model;
using DesignPatterns.youtubeChannel.pattern;

namespace DesignPatterns.youtubeChannel.observerPattern
{
    class YouTubeApp
    {
        private Dictionary<String, YouTubeChannel> channels;
        public Dictionary<String, YouTubeChannel> Channels
        {
            get { return channels; }
            set { channels = value; }
        }

        private List<YouTubeVideo> advertisements;

        internal List<YouTubeVideo> Advertisements
        {
            get { return advertisements; }
            set { advertisements = value; }
        }

        private static YouTubeApp instance;

        private YouTubeApp()
        {
            this.channels = new Dictionary<String, YouTubeChannel>();
            this.advertisements = new List<YouTubeVideo>();
            this.advertisements.Add(new YouTubeVideo("add", "Youtube advertisement description", "www.youtube,com", 4));
        }

        public static YouTubeApp getInstance()
        {
            if (instance == null)
            {
                instance = new YouTubeApp();
            }

            return instance;
        }

        public void createYouTubeChannel()
        {
            Console.WriteLine("Enter name for the channel: ");
            String name = Console.ReadLine();
            Console.WriteLine("Enter type of channel (basic/premium)");
            String type = Console.ReadLine();

            try
            {
                if (type.Equals("basic"))
                {
                    channels.Add(name, new YouTubeChannel(name,new AdvertisingPlaying()));
                }
                else
                {
                    channels.Add(name, new YouTubeChannel(name,new NoAdvertisingPlaying()));
                }
                
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

        public void createNewPlaylist()
        {
            Console.WriteLine("Enter youtube channel: ");
            String channelName = Console.ReadLine();
            try
            {
                YouTubeChannel channel = channels[channelName];
                channel.createPlaylist();
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Youtube channel name does not exist!");
            }
        }

        public void playPlaylist()
        {
            Console.WriteLine("Enter youtube channel: ");
            String channelName = Console.ReadLine();
            try
            {
                YouTubeChannel channel = channels[channelName];
                channel.playPlaylist();
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Youtube channel name does not exist!");
            }
        }

        public void addVideoToPlaylist()
        {
            Console.WriteLine("Enter youtube channel: ");
            String channelName = Console.ReadLine();
            try
            {
                YouTubeChannel channel = channels[channelName];
                channel.addVideoToPlaylist();
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Youtube channel name does not exist!");
            }
        }

        public void displayPlaylists()
        {
            Console.WriteLine("Enter youtube channel: ");
            String channelName = Console.ReadLine();
            try
            {
                YouTubeChannel channel = channels[channelName];
                channel.displayPlaylists();
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Youtube channel name does not exist!");
            }
        }

        public void playVideo()
        {
            Console.WriteLine("Enter youtube channel: ");
            String channelName = Console.ReadLine();
            try
            {
                YouTubeChannel channel = channels[channelName];
                channel.playVideo();
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Youtube channel name does not exist!");
            }
        }

        public void switchTypeOfChannel()
        {
            Console.WriteLine("Enter youtube channel: ");
            String channelName = Console.ReadLine();
            try
            {
                YouTubeChannel channel = channels[channelName];
                channel.switchTypeOfChannel();
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Youtube channel name does not exist!");
            }
        }

        public void displayMenu()
        {
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("Options:                                                             ");
            Console.WriteLine("1. Create YouTube channel                                            ");
            Console.WriteLine("2. Create video for youtube channel                                  ");
            Console.WriteLine("3. Display all channels                                              ");
            Console.WriteLine("4. Subscribe channel                                                 ");
            Console.WriteLine("5. Unsubscribe channel                                               ");
            Console.WriteLine("6. View youtube channel notifications                                ");
            Console.WriteLine("7. Clear youtube channel notifications                               ");
            Console.WriteLine("8. Create new playlist                                               ");
            Console.WriteLine("9. Add video to playlist                                             ");
            Console.WriteLine("10. Display all playlists                                            ");
            Console.WriteLine("11. Play video                                                       ");
            Console.WriteLine("12. Play playlist                                                    ");
            Console.WriteLine("13. Switch type of channel (add/noAdd)                               ");
            Console.WriteLine("0. Exit                                                              ");
            Console.WriteLine("---------------------------------------------------------------------");
        }

        public int callAction()
        {
            int option = 0;
            Console.Write("Command: ");
            while (!Int32.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine("Invalid input, please enter a valid option (from 0 to 13)!");
                Console.WriteLine("---------------------------------------------------------------------");
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
                case 8:
                    this.createNewPlaylist();
                    break;
                case 9:
                    this.addVideoToPlaylist();
                    break;
                case 10:
                    this.displayPlaylists();
                    break;
                case 11:
                    this.playVideo();
                    break;
                case 12:
                    this.playPlaylist();
                    break;
                case 13:
                    this.switchTypeOfChannel();
                    break;
                case 0:
                    Console.WriteLine("Exiting from YouTube app...");
                    break;
                default:
                    Console.WriteLine("---------------------------------------------------------------------");
                    Console.WriteLine("Invalid input, please enter a valid option (from 0 to 13)!");
                    break;
            }
            Console.WriteLine("---------------------------------------------------------------------");
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
