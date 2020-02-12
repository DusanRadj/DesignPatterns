using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using DesignPatterns.youtubeChannel.observerPattern.interfaces;

namespace DesignPatterns.youtubeChannel.observerPattern.model
{
    class YouTubeChannel : IObservable, IObserver, ISubscribe
    {
        private String name;
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        private Dictionary<String,YouTubeVideo> videos;
        public Dictionary<String,YouTubeVideo> Videos
        {
            get { return videos; }
            set { videos = value; }
        }
        
        private List<IObserver> subscribers;

        private Dictionary<String,YouTubeChannel> subscribedTo;
        private List<Notification> notifications;

        private Dictionary<String,Playlist> playlists;

        public YouTubeChannel(String name)
        {
            this.name = name;
            this.videos = new Dictionary<String,YouTubeVideo>();
            this.subscribers = new List<IObserver>();

            this.subscribedTo = new Dictionary<String, YouTubeChannel>();
            this.notifications = new List<Notification>();
            this.playlists = new Dictionary<String,Playlist>();
        }

        public void createPlaylist()
        {
            Console.Write("Enter playlist name: ");
            String playlistName = Console.ReadLine();
            Playlist playlist = new Playlist(playlistName);
            this.playlists.Add(playlistName,playlist);
        }

        public void addVideoToPlaylist()
        {
            Console.Write("Enter playlist name: ");
            String playlistName = Console.ReadLine();

            try
            {
                Playlist playlist = this.playlists[playlistName];
                Console.Write("Enter video title: ");
                String videoTitle = Console.ReadLine();
                try
                {
                    YouTubeVideo video = this.videos[videoTitle];
                    playlist.addVideoToPlaylist(video);
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("Video of given title does not exist!");
                }
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Playlist of given name does not exist!");
            }
        }

        public void removeVideoFromPlaylist()
        {
            Console.Write("Enter playlist name: ");
            String playlistName = Console.ReadLine();

            try
            {
                Playlist playlist = this.playlists[playlistName];
                playlist.removeVideoFromPlaylist();
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Playlist of given name does not exist!");
            }
        }

        public void registerObserver(IObserver observer)
        {
            this.subscribers.Add(observer);
        }

        public void removeObserver(IObserver observer)
        {
            this.subscribers.Remove(observer);
        }

        public void notifyObservers(Notification notification)
        {
            foreach (IObserver subscriber in subscribers)
            {
                subscriber.update(notification); 
            }
        }

        public void subscribe(YouTubeChannel toSubscribe)
        {
            if (this == toSubscribe)
            {
                Console.WriteLine("You can not subscribe to your own channel!");
                return;
            }

            try
            {
                this.subscribedTo.Add(toSubscribe.Name, toSubscribe);
                toSubscribe.registerObserver(this);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("You are already subscribed to this channel!");
            }
        }

        public void unsubscribe(YouTubeChannel toUnsubscribe)
        {
            this.subscribedTo.Remove(toUnsubscribe.Name);
            toUnsubscribe.removeObserver(this);
        }

        public void update(Notification notification)
        {
            this.notifications.Add(notification);

            Console.WriteLine(this.name + ": Channel " + notification.ChannelName + " you subscribed to, has uploaded a new video "
                + notification.Title + " on link (" + notification.Link + ")");

        }

        public void clearNotifications()
        {
            this.notifications.Clear();
        }

        public void displayNotifications()
        {
            foreach (Notification notification in notifications)
            {
                Console.WriteLine(this.name + ": Channel " + notification.ChannelName + " you subscribed to, has uploaded a new video "
                + notification.Title + " on link (" + notification.Link + ")");
            }
        }

        public void createNewVideo()
        {
            Console.Write("Enter title: ");
            String title = Console.ReadLine();

            Console.Write("Enter description: ");
            String description = Console.ReadLine();

            String link = this.createNewLink();

            Console.Write("Enter length: ");
            int length = Convert.ToInt32(Console.ReadLine());

            YouTubeVideo newVideo = new YouTubeVideo(title, description, link, length);
            this.videos.Add(title,newVideo);

            Console.WriteLine("Channel " + this.name + " created video " + newVideo.Title + " ( " + newVideo.Length + " ) ");
            
            this.notifyObservers(new Notification(newVideo.Title, newVideo.Link, this.name));
        }

        private String createNewLink()
        {
            String link = "www.youtube.com/" + this.Name + "/";
            String now = DateTime.Now.ToString();
            now = now.Replace('/', ' ').Replace(':', ' ').Replace(" ", string.Empty);
            now = now.Remove(now.Length - 1); //ujutru i uvece moze doci do poklapanja, pa se ostavlja A i P (iz PM i AM)         
            return link+now;
        }

        public override string ToString()
        {
            String retVal = "YouTube Channel: " + this.name;

            if (this.subscribedTo.Count != 0)
            {
                retVal += ", subscribed to channels: ";

                foreach (KeyValuePair<String, YouTubeChannel> channel in subscribedTo)
                {
                    retVal += channel.Value.Name + ", ";
                }

                retVal = retVal.Remove(retVal.Length - 2);
            }
            else
            {
                retVal += " has not subscribed to any channel";
            }

            return retVal;
        }
        
    }
}
