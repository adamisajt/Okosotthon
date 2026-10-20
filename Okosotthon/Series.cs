using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    public class Series : IContent
    {
        private string title;
        private List<Video> videos;

        public Series(string title, Video video)
        {
            this.title = title;

            this.videos = new List<Video>();
            this.videos.Add(video);
        }

        public Series(string title, List<Video> videos)
        {
            this.title = title;
            this.videos = videos;
        }

        public string getTitle()
        {
            return this.title;
        }

        public int getLength()
        {
            int teljesHossz = 0;

            foreach (Video video in this.videos)
            {
                teljesHossz = teljesHossz + video.getLength();
            }

            return teljesHossz;
        }
    }
}