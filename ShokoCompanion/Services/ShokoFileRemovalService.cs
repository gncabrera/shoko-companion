using Shoko.Models.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShokoCompanion.Services
{
    internal class ShokoFileRemovalService
    {
        private static ShokoFileRemovalService instance = null;
        private static readonly object padlock = new object();

        private static string GROUP_ERAI_RAWS = "erai-raws";
        private static string GROUP_SUBSPLEASE = "subsplease";
        public static int USER_ID { get { return 1; } }

        ShokoFileRemovalService()
        {
        }

        public static ShokoFileRemovalService Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ShokoFileRemovalService();
                    }
                    return instance;
                }
            }
        }

        internal bool IsDeleteCandidate(CL_AnimeEpisode_User episode, CL_VideoDetailed detail, IEnumerable<CL_VideoDetailed> episodeDetails)
        {
            if(episodeDetails.Count() == 2)
            {
                // Delete if: Exist Erai-raws & Subsplease & Current detail is Subsplease
                var eraiRawsFile = episodeDetails.FirstOrDefault(e => e.AniDB_Anime_GroupName != null && e.AniDB_Anime_GroupName.ToLower() == GROUP_ERAI_RAWS);
                var subspleaseFile = episodeDetails.FirstOrDefault(e => e.AniDB_Anime_GroupName != null && e.AniDB_Anime_GroupName.ToLower() == GROUP_SUBSPLEASE);
                if (eraiRawsFile != null && subspleaseFile != null)
                {
                    return detail.AniDB_Anime_GroupName.ToLower() == GROUP_SUBSPLEASE;
                }

                // Delete if: Same Group, Different Version and Current detail is lowest version
                var firstFile = episodeDetails.ElementAt(0);
                var secondFile = episodeDetails.ElementAt(1);
                if (firstFile.AniDB_GroupID == secondFile.AniDB_GroupID
                    && firstFile.AniDB_File_FileVersion != secondFile.AniDB_File_FileVersion) {
                    var minVersion = episodeDetails.Min(e => e.AniDB_File_FileVersion);
                    return detail.AniDB_File_FileVersion == minVersion;
                }
            }

            return false;
        }
    }
}
