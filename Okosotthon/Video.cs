using System;
using System.Collections.Generic;
using System.Text;


namespace Okosotthon
{
    public class Video
    {
        private string title;
        private int length;

        public Video(string title, int length)
        {
            this.title = title;
            this.length = length;
        }

        public string getTitle()
        {
            return this.title;
        }

        public int getLength()
        {
            return this.length;
        }
    }
}