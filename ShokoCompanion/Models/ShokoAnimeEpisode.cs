using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShokoCompanion.Models
{
    internal class ShokoAnimeEpisode
    {
        public DateTime DateTimeUpdated { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public int AniDB_EpisodeID { get; set; }
        public int EpisodeNumber { get; set; }
        public string EpisodeNameRomaji { get; set; }
        public string EpisodeNameEnglish { get; set; }
        public string Description { get; set; }
        public int EpisodeType { get; set; }
        public int LocalFileCount { get; set; }
        public int UnwatchedEpCountSeries { get; set; }
        public int AniDB_LengthSeconds { get; set; }
        public string AniDB_Rating { get; set; }
        public string AniDB_Votes { get; set; }
        public string AniDB_RomajiName { get; set; }
        public string AniDB_EnglishName { get; set; }
        public DateTime AniDB_AirDate { get; set; }
        public int AnimeEpisode_UserID { get; set; }
        public int JMMUserID { get; set; }
        public int AnimeEpisodeID { get; set; }
        public int AnimeSeriesID { get; set; }
        public object WatchedDate { get; set; }
        public int PlayedCount { get; set; }
        public int WatchedCount { get; set; }
        public int StoppedCount { get; set; }
    }
}
