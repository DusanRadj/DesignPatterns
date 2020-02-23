using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesignPatterns.googleAccount.pattern;

namespace DesignPatterns.youtubeChannel.observerPattern.model
{
    class MyMail 
    {
        private String from;
        private String to;
        private String subject;
        private String text;

        public MyMail(String from, String to, String subject, String text)
        {
            this.from = from;
            this.to = to;
            this.subject = subject;
            this.text = text;
        }

        public override string ToString()
        {
            String retVal = "From: " + this.from + ", To: " + this.to;
            retVal += Environment.NewLine;
            retVal += "Subject: " + this.subject;
            retVal += Environment.NewLine;
            retVal += "Text: " + this.text;
            retVal += Environment.NewLine;

            return retVal;
        }

        #region properties

        public String Text
        {
            get { return text; }
            set { text = value; }
        }
        public String Subject
        {
            get { return subject; }
            set { subject = value; }
        }
        public String To
        {
            get { return to; }
            set { to = value; }
        }
        public String From
        {
            get { return from; }
            set { from = value; }
        }

        #endregion



    }
}
