using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesignPatterns.youtubeChannel.observerPattern.interfaces;

namespace DesignPatterns.youtubeChannel.observerPattern.model
{
    class GoogleAccount : IObserver, ISubscribe
    {
        private Dictionary<String,YouTubeChannel> subscribedTo;
        private List<MyMail> emails;
        private String gMailAddress;
        
        private String username;
        public String Username
        {
            get { return username; }
            set { username = value; }
        }

        public GoogleAccount(String username)
        {
            this.subscribedTo = new Dictionary<String, YouTubeChannel>();
            this.emails = new List<MyMail>();
            this.username = username;
            this.gMailAddress = username + "@gmail.com";
        }

        public void update(Notification notification)
        {
            String subject = "Channel " + notification.ChannelName + " has uploaded a new video!";
            String text = subject + Environment.NewLine;
            text += "Go to " + notification.Link + " to check it out!";
            MyMail newMail = new MyMail("www.youtube.com", this.gMailAddress, subject, text);
            Console.WriteLine(this.username + ", you have recieved a new mail: " + subject); 
            this.emails.Add(newMail);
        }

        public void subscribe(YouTubeChannel toSubscribe)
        {
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

        public void displayAllMails()
        {
            foreach (MyMail mail in emails)
            {
                Console.WriteLine(mail.ToString());
            }
        }

        public override string ToString()
        {
            String retVal = "Google account: " + this.Username;

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
