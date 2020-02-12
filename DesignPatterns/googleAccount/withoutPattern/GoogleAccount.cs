using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesignPatterns.youtubeChannel.observerPattern.model;

namespace DesignPatterns.youtubeChannel.withoutPattern
{
    class GoogleAccount : ISubscribe
    {
        private Dictionary<String, YouTubeChannel> subscribedTo;

        private List<MyMail> emails;
        public List<MyMail> Emails
        {
            get { return emails; }
            set { emails = value; }
        }
     
        private String gMailAddress;
        public String GMailAddress
        {
            get { return gMailAddress; }
            set { gMailAddress = value; }
        }

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
        
        //bez update funkcije

        public void subscribe(YouTubeChannel toSubscribe)
        {
            try
            {
                this.subscribedTo.Add(toSubscribe.Name, toSubscribe);
                toSubscribe.GoogleAccountSubscribers.Add(this);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("You are already subscribed to this channel!");
            }
        }

        public void unsubscribe(YouTubeChannel toUnsubscribe)
        {
            this.subscribedTo.Remove(toUnsubscribe.Name);
            toUnsubscribe.GoogleAccountSubscribers.Remove(this);
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
