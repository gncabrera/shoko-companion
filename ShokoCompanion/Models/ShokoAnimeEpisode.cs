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
        public long AniDB_EpisodeID { get; set; }
        public long EpisodeNumber { get; set; }
        public string EpisodeNameRomaji { get; set; }
        public string EpisodeNameEnglish { get; set; }
        public string Description { get; set; }
        public long EpisodeType { get; set; }
        public long LocalFileCount { get; set; }
        public long UnwatchedEpCountSeries { get; set; }
        public long AniDB_LengthSeconds { get; set; }
        public string AniDB_Rating { get; set; }
        public string AniDB_Votes { get; set; }
        public string AniDB_RomajiName { get; set; }
        public string AniDB_EnglishName { get; set; }
        public DateTime AniDB_AirDate { get; set; }
        public long AnimeEpisode_UserID { get; set; }
        public long JMMUserID { get; set; }
        public long AnimeEpisodeID { get; set; }
        public long AnimeSeriesID { get; set; }
        public object WatchedDate { get; set; }
        public long PlayedCount { get; set; }
        public long WatchedCount { get; set; }
        public long StoppedCount { get; set; }
    }
}
