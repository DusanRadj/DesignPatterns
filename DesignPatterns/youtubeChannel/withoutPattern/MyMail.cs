using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.youtubeChannel.withoutPattern
{
    class MyMail
    {
        private String from;
        public String From
        {
            get { return from; }
            set { from = value; }
        }

        private String to;
        public String To
        {
            get { return to; }
            set { to = value; }
        }

        private String subject;
        public String Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        private String text;
        public String Text
        {
            get { return text; }
            set { text = value; }
        }

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


    }
}
