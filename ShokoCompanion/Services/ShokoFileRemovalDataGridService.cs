using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShokoCompanion.Services
{
    internal class ShokoFileRemovalDataGridService
    {
       
    }
    public static class ShokoDataGridColumns
    {
        public static string CheckBox = "  ";
        public static int CheckBoxIndex = 0;
        public static string EpisodeIndex = "EpisodeIndex";
        public static string VideoLocalPlaceID = "VideoLocalPlaceID";
        public static string AnimeName = "Anime";
        public static string EpisodeNumber = "Ep#";
        public static string EpisodeName = "Ep Name";
        public static string Filename = "Filename";

        
    }
    public class ShokoDataGridColumn
    {
        public string Name { get; set; }
        public Type ColumnType { get; set; }
        public int Index { get; set; }
    }
}
