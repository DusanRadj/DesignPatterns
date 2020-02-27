using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesignPatterns.youtubeChannel.observerPattern.model;

namespace DesignPatterns.youtubeChannel.withoutPattern
{
    abstract class YouTubeChannel : ISubscribe
    {
        private String name;
        private Dictionary<String, YouTubeVideo> videos;
        protected Dictionary<String, Playlist> playlists;
        private Dictionary<String, YouTubeChannel> subscribedTo;
        private List<Notification> notifications;

        // vezivanje za konkretnu implementaciju, u svakom novom slucaju ponovno vezivanje za konkretnu implementaciju
        private List<YouTubeChannel> youTubeSubscribers; 
        private List<GoogleAccount> googleAccountSubscribers;

        public YouTubeChannel(String name)
        {
            this.name = name;
            this.videos = new Dictionary<String,YouTubeVideo>();
            this.playlists = new Dictionary<String, Playlist>();
            this.youTubeSubscribers = new List<YouTubeChannel>();
            this.googleAccountSubscribers = new List<GoogleAccount>();

            this.subscribedTo = new Dictionary<String, YouTubeChannel>();
            this.notifications = new List<Notification>();
        }

        public abstract void createPlaylist();

        public void playPlaylist()
        {
            Console.Write("Enter playlist name: ");
            String playlistName = Console.ReadLine();

            try
            {
                Playlist playlist = this.playlists[playlistName];
                playlist.play();
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Playlist of given name does not exist!");
            }
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
                    playlist.addVideo(video);
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
                playlist.removeVideo();
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Playlist of given name does not exist!");
            }
        }

        public void displayPlaylists()
        {
            foreach (KeyValuePair<String, Playlist> pair in this.playlists)
            {
                pair.Value.display();
            }
        } 

        //bez registerObserver,removeObserver,notifyObservers kao i update funkcije

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
                toSubscribe.youTubeSubscribers.Add(this); //obavestavamo direktno kanal na koji se subscribe-ujemo, konkretno preko liste
            }
            catch (ArgumentException)
            {
                Console.WriteLine("You are already subscribed to this channel!");
            }
        }

        public void unsubscribe(YouTubeChannel toUnsubscribe)
        {
            this.subscribedTo.Remove(toUnsubscribe.Name);
            toUnsubscribe.youTubeSubscribers.Remove(this);
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

            Notification notification = new Notification(newVideo.Title, newVideo.Link, this.name);
            
            //direktna manipulacija objektima konkretnih klasa koje su subscribe-ovane, tight coupling, vezivanje za implementaciju klase objekata
            //koji su subscribe-ovani, umesto interfejsa
            foreach (YouTubeChannel channel in this.youTubeSubscribers)
            {
                channel.notifications.Add(notification);
                Console.WriteLine("Notification about recently created video sent from: " + this.Name + " to: " + channel.Name);
            }

            String subject = "Channel " + notification.ChannelName + " has uploaded a new video!";
            String text = subject + Environment.NewLine;
            text += "Go to " + notification.Link + " to check it out!";

            foreach (GoogleAccount account in this.googleAccountSubscribers)
            {
                MyMail newMail = new MyMail("www.youtube.com", account.GMailAddress, subject, text);
                account.Inbox.Add(newMail);
                Console.WriteLine(this.Name+ ": Email about created video sent to " + account.GMailAddress); 
            }

        }

        public abstract void playVideo();

        private String createNewLink()
        {
            String link = "www.youtube.com/" + this.Name + "/";
            String now = DateTime.Now.ToString();
            now = now.Replace('/', ' ').Replace(':', ' ').Replace(" ", string.Empty);
            now = now.Remove(now.Length - 1); //ujutru i uvece moze doci do poklapanja, pa se ostavlja A i P (iz PM i AM)         
            return link + now;
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

        #region properties
        public List<Notification> Notifications
        {
            get { return notifications; }
            set { notifications = value; }
        }
        internal List<GoogleAccount> GoogleAccountSubscribers
        {
            get { return googleAccountSubscribers; }
            set { googleAccountSubscribers = value; }
        }
        internal List<YouTubeChannel> YouTubeSubscribers
        {
            get { return youTubeSubscribers; }
            set { youTubeSubscribers = value; }
        }
        
        public String Name
        {
            get { return name; }
            set { name = value; }
        }


        protected Dictionary<String, YouTubeVideo> Videos
        {
            get { return videos; }
            set { videos = value; }
        }

        #endregion

    }
}
