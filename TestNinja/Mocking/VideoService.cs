using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace TestNinja.Mocking
{
    public class VideoService
    {
        private readonly IFileReader _fileReader;

        /// <summary>
        /// Poor man's dependency injection
        /// Unit test Mock constructor. Pass the mock file reader is the 
        /// constructor is called by the unit test
        /// </summary>
        /// <param name="fileReader"></param>
        public VideoService(IFileReader fileReader = null)
        {             
            //If the the file reader is null, new up a file reader
            _fileReader = fileReader ?? new FileReader();
        }

        public string ReadVideoTitle()
        {
            var str = _fileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);

            if (video == null)
                return "Error parsing the video.";

            return video.Title;
        }

        public string GetUnprocessedVideoAsCsv()
        {
            var videoIds = new List<int>();

            using (var context = new VideoContext())
            {
                var videos = (
                    from video in context.Videos
                    where !video.IsProcessed
                    select video).ToList();

                foreach (var v in videos)
                    videoIds.Add(v.Id);

                return string.Join(",", videoIds);
            }
        }

        public class Video
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public bool IsProcessed { get; set; }
        }

        public class VideoContext : DbContext
        {
            public DbSet<Video> Videos { get; set; }
        }
    }
}
