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
        private List<MyMail> inbox;
        private List<MyMail> outbox;
        private String gMailAddress;
        private String username;
        
        public GoogleAccount(String username)
        {
            this.subscribedTo = new Dictionary<String, YouTubeChannel>();
            this.inbox = new List<MyMail>();
            this.outbox = new List<MyMail>();
            this.username = username;
            this.gMailAddress = username + "@gmail.com";
        }

        public void sendMail(GoogleAccount reciever)
        {
            Console.WriteLine("Enter subject: ");
            String subject = Console.ReadLine();
            Console.WriteLine("Enter text: ");
            String text = Console.ReadLine();
            MyMail newMail = new MyMail(this.gMailAddress, reciever.GMailAddress, subject, text);
            this.Outbox.Add(newMail);
            reciever.Inbox.Add(newMail);
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
            Console.WriteLine("Inbox:");
            Console.WriteLine();

            foreach (MyMail mail in inbox)
            {
                Console.WriteLine(mail.ToString());
            }
            Console.WriteLine();

            Console.WriteLine("Outbox:");
            Console.WriteLine();

            foreach (MyMail mail in outbox)
            {
                Console.WriteLine(mail.ToString());
            }
            Console.WriteLine();
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


        #region properties
        public String Username
        {
            get { return username; }
            set { username = value; }
        }
        public String GMailAddress
        {
            get { return gMailAddress; }
            set { gMailAddress = value; }
        }

        internal List<MyMail> Outbox
        {
            get { return outbox; }
            set { outbox = value; }
        }
        internal List<MyMail> Inbox
        {
            get { return inbox; }
            set { inbox = value; }
        }
        #endregion
    }
}
