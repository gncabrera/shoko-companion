using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShokoCompanion.Models
{
    public class ShokoImportFolder
    {
        public long? IsWatched { get; set; }
        public long? IsDropSource { get; set; }
        public long? IsDropDestination { get; set; }
        public string ImportFolderLocation { get; set; }
        public object CloudAccount { get; set; }
        public string CloudAccountName { get; set; }
        public long? ImportFolderID { get; set; }
        public long? ImportFolderType { get; set; }
        public string ImportFolderName { get; set; }
        public object CloudID { get; set; }
    }

    public class ShokoPlace
    {
        public ShokoImportFolder ImportFolder { get; set; }
        public long? VideoLocal_Place_ID { get; set; }
        public long? VideoLocalID { get; set; }
        public string FilePath { get; set; }
        public long? ImportFolderID { get; set; }
        public long? ImportFolderType { get; set; }
    }

    public class ShokoStream
    {
        public string Language { get; set; }
        public long? Duration { get; set; }
        public long? Height { get; set; }
        public long? Width { get; set; }
        public long? Bitrate { get; set; }
        public long? SubIndex { get; set; }
        public long? Id { get; set; }
        public string ScanType { get; set; }
        public long? RefFrames { get; set; }
        public string Profile { get; set; }
        public long? HeaderStripping { get; set; }
        public string FrameRateMode { get; set; }
        public double FrameRate { get; set; }
        public string ColorSpace { get; set; }
        public string CodecID { get; set; }
        public string ChromaSubsampling { get; set; }
        public long? Cabac { get; set; }
        public long? BitDepth { get; set; }
        public long? Index { get; set; }
        public string Codec { get; set; }
        public long? StreamType { get; set; }
        public string LanguageCode { get; set; }
        public long? Channels { get; set; }
        public long? Selected { get; set; }
        public long? Default { get; set; }
        public long? Forced { get; set; }
        public long? SamplingRate { get; set; }
        public string Title { get; set; }
        public string Format { get; set; }
    }

    public class ShokoPart
    {
        public long? Accessible { get; set; }
        public long? Exists { get; set; }
        public List<ShokoStream> Streams { get; set; }
        public long? Size { get; set; }
        public long? Duration { get; set; }
        public long? Id { get; set; }
    }

    public class ShokoMedia
    {
        public List<ShokoPart> Parts { get; set; }
        public long? Duration { get; set; }
        public string VideoFrameRate { get; set; }
        public string Container { get; set; }
        public string VideoCodec { get; set; }
        public string AudioCodec { get; set; }
        public long? AudioChannels { get; set; }
        public double AspectRatio { get; set; }
        public long? Height { get; set; }
        public long? Width { get; set; }
        public long? Bitrate { get; set; }
        public long? Id { get; set; }
        public string VideoResolution { get; set; }
        public long? OptimizedForStreaming { get; set; }
    }

    public class ShokoVideoDetailed
    {
        public long? AnimeEpisodeID { get; set; }
        public long? Percentage { get; set; }
        public long? EpisodeOrder { get; set; }
        public long? CrossRefSource { get; set; }
        public long? VideoLocalID { get; set; }
        public string VideoLocal_FileName { get; set; }
        public string VideoLocal_Hash { get; set; }
        public long? VideoLocal_FileSize { get; set; }
        public long? VideoLocal_IsWatched { get; set; }
        public object VideoLocal_WatchedDate { get; set; }
        public long? VideoLocal_ResumePosition { get; set; }
        public long? VideoLocal_IsIgnored { get; set; }
        public string VideoLocal_CRC32 { get; set; }
        public string VideoLocal_MD5 { get; set; }
        public string VideoLocal_SHA1 { get; set; }
        public long? VideoLocal_HashSource { get; set; }
        public long? VideoLocal_IsVariation { get; set; }
        public List<ShokoPlace> Places { get; set; }
        public string VideoInfo_VideoCodec { get; set; }
        public string VideoInfo_VideoBitrate { get; set; }
        public string VideoInfo_VideoBitDepth { get; set; }
        public string VideoInfo_VideoFrameRate { get; set; }
        public string VideoInfo_VideoResolution { get; set; }
        public string VideoInfo_AudioCodec { get; set; }
        public string VideoInfo_AudioBitrate { get; set; }
        public long? VideoInfo_Duration { get; set; }
        public long? AniDB_FileID { get; set; }
        public long? AniDB_AnimeID { get; set; }
        public long? AniDB_GroupID { get; set; }
        public string AniDB_File_Source { get; set; }
        public string AniDB_File_AudioCodec { get; set; }
        public string AniDB_File_VideoCodec { get; set; }
        public string AniDB_File_VideoResolution { get; set; }
        public string AniDB_File_FileExtension { get; set; }
        public long? AniDB_File_LengthSeconds { get; set; }
        public string AniDB_File_Description { get; set; }
        public long? AniDB_File_ReleaseDate { get; set; }
        public string AniDB_Anime_GroupName { get; set; }
        public string AniDB_Anime_GroupNameShort { get; set; }
        public long? AniDB_Episode_Rating { get; set; }
        public long? AniDB_Episode_Votes { get; set; }
        public string AniDB_CRC { get; set; }
        public string AniDB_MD5 { get; set; }
        public string AniDB_SHA1 { get; set; }
        public long? AniDB_File_FileVersion { get; set; }
        public long? AniDB_File_IsCensored { get; set; }
        public long? AniDB_File_IsDeprecated { get; set; }
        public long? AniDB_File_IsChaptered { get; set; }
        public long? AniDB_File_InternalVersion { get; set; }
        public string LanguagesAudio { get; set; }
        public string LanguagesSubtitle { get; set; }
        public object ReleaseGroup { get; set; }
        public ShokoMedia Media { get; set; }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                ShokoVideoDetailed p = (ShokoVideoDetailed)obj;
                return p.AnimeEpisodeID == p.AnimeEpisodeID;
            }
        }

        public override int GetHashCode()
        {
            return AnimeEpisodeID.GetHashCode();
        }
    }
}
