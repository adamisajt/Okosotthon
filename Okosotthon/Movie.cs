using System;
using System.Collections.Generic;
using System.Text;
    

namespace Okosotthon
{
    public class Movie : IContent
    {
        private Video video;

        public Movie(Video video)
        {
            this.video = video;
        }

        public string getTitle()
        {
            return this.video.getTitle();
        }

        public int getLength()
        {
            return this.video.getLength();
        }
    }
}