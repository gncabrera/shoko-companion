using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShokoCompanion.Models
{
    public class ShokoImportFolder
    {
        public int IsWatched { get; set; }
        public int IsDropSource { get; set; }
        public int IsDropDestination { get; set; }
        public string ImportFolderLocation { get; set; }
        public object CloudAccount { get; set; }
        public string CloudAccountName { get; set; }
        public int ImportFolderID { get; set; }
        public int ImportFolderType { get; set; }
        public string ImportFolderName { get; set; }
        public object CloudID { get; set; }
    }

    public class ShokoPlace
    {
        public ShokoImportFolder ImportFolder { get; set; }
        public int VideoLocal_Place_ID { get; set; }
        public int VideoLocalID { get; set; }
        public string FilePath { get; set; }
        public int ImportFolderID { get; set; }
        public int ImportFolderType { get; set; }
    }

    public class ShokoStream
    {
        public string Language { get; set; }
        public int Duration { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Bitrate { get; set; }
        public int SubIndex { get; set; }
        public int Id { get; set; }
        public string ScanType { get; set; }
        public int RefFrames { get; set; }
        public string Profile { get; set; }
        public int HeaderStripping { get; set; }
        public string FrameRateMode { get; set; }
        public double FrameRate { get; set; }
        public string ColorSpace { get; set; }
        public string CodecID { get; set; }
        public string ChromaSubsampling { get; set; }
        public int Cabac { get; set; }
        public int BitDepth { get; set; }
        public int Index { get; set; }
        public string Codec { get; set; }
        public int StreamType { get; set; }
        public string LanguageCode { get; set; }
        public int Channels { get; set; }
        public int Selected { get; set; }
        public int Default { get; set; }
        public int Forced { get; set; }
        public int? SamplingRate { get; set; }
        public string Title { get; set; }
        public string Format { get; set; }
    }

    public class ShokoPart
    {
        public int Accessible { get; set; }
        public int Exists { get; set; }
        public List<ShokoStream> Streams { get; set; }
        public int Size { get; set; }
        public int Duration { get; set; }
        public int Id { get; set; }
    }

    public class ShokoMedia
    {
        public List<ShokoPart> Parts { get; set; }
        public int Duration { get; set; }
        public string VideoFrameRate { get; set; }
        public string Container { get; set; }
        public string VideoCodec { get; set; }
        public string AudioCodec { get; set; }
        public int AudioChannels { get; set; }
        public double AspectRatio { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Bitrate { get; set; }
        public int Id { get; set; }
        public string VideoResolution { get; set; }
        public int OptimizedForStreaming { get; set; }
    }

    public class ShokoVideoDetailed
    {
        public int AnimeEpisodeID { get; set; }
        public int Percentage { get; set; }
        public int EpisodeOrder { get; set; }
        public int CrossRefSource { get; set; }
        public int VideoLocalID { get; set; }
        public string VideoLocal_FileName { get; set; }
        public string VideoLocal_Hash { get; set; }
        public int VideoLocal_FileSize { get; set; }
        public int VideoLocal_IsWatched { get; set; }
        public object VideoLocal_WatchedDate { get; set; }
        public int VideoLocal_ResumePosition { get; set; }
        public int VideoLocal_IsIgnored { get; set; }
        public string VideoLocal_CRC32 { get; set; }
        public string VideoLocal_MD5 { get; set; }
        public string VideoLocal_SHA1 { get; set; }
        public int VideoLocal_HashSource { get; set; }
        public int VideoLocal_IsVariation { get; set; }
        public List<ShokoPlace> Places { get; set; }
        public string VideoInfo_VideoCodec { get; set; }
        public string VideoInfo_VideoBitrate { get; set; }
        public string VideoInfo_VideoBitDepth { get; set; }
        public string VideoInfo_VideoFrameRate { get; set; }
        public string VideoInfo_VideoResolution { get; set; }
        public string VideoInfo_AudioCodec { get; set; }
        public string VideoInfo_AudioBitrate { get; set; }
        public int VideoInfo_Duration { get; set; }
        public int AniDB_FileID { get; set; }
        public int AniDB_AnimeID { get; set; }
        public int AniDB_GroupID { get; set; }
        public string AniDB_File_Source { get; set; }
        public string AniDB_File_AudioCodec { get; set; }
        public string AniDB_File_VideoCodec { get; set; }
        public string AniDB_File_VideoResolution { get; set; }
        public string AniDB_File_FileExtension { get; set; }
        public int AniDB_File_LengthSeconds { get; set; }
        public string AniDB_File_Description { get; set; }
        public int AniDB_File_ReleaseDate { get; set; }
        public string AniDB_Anime_GroupName { get; set; }
        public string AniDB_Anime_GroupNameShort { get; set; }
        public int AniDB_Episode_Rating { get; set; }
        public int AniDB_Episode_Votes { get; set; }
        public string AniDB_CRC { get; set; }
        public string AniDB_MD5 { get; set; }
        public string AniDB_SHA1 { get; set; }
        public int AniDB_File_FileVersion { get; set; }
        public int AniDB_File_IsCensored { get; set; }
        public int AniDB_File_IsDeprecated { get; set; }
        public int AniDB_File_IsChaptered { get; set; }
        public int AniDB_File_InternalVersion { get; set; }
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
