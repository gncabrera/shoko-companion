using ShokoCompanion.Models;
using ShokoCompanion.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShokoCompanion
{
    public partial class RemoveDuplicateFiles : Form
    {
        ShokoService shokoService = ShokoService.Instance;

        
        public RemoveDuplicateFiles()
        {
            InitializeComponent();
        }

        private async void loadFilesBtn_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            var allVideoDetails = await GetAllVideoDetails();

            dt.Columns.Add("  ", typeof(bool));
            dt.Columns.Add("EpisodeIndex", typeof(int));
            dt.Columns.Add("VideoLocalPlaceID", typeof(int));
            dt.Columns.Add("Anime", typeof(string));
            dt.Columns.Add("Ep#", typeof(int));
            dt.Columns.Add("Ep Name", typeof(string));
            dt.Columns.Add("File Name", typeof(string));

            var episodeIndex = 0;
            foreach (var episode in allVideoDetails.Keys.OrderBy(c => c.AnimeSeriesID).ThenBy(c => c.EpisodeNumber))
            {
                var details = allVideoDetails[episode];

                for (int i = 0; i < details.Count(); i++)
                {
                    var detail = details[i];
                    dt.Rows.Add(BuildRow(i == 0, episodeIndex, episode, detail));
                }
                episodeIndex++;

            }
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["EpisodeIndex"].Visible = false;
            dataGridView1.Columns["VideoLocalPlaceID"].Visible = false;
        }

        private object[] BuildRow(bool showEpisodeName, int episodeIndex, ShokoAnimeEpisode episode, ShokoVideoDetailed detail)
        {
            return new object[] {
                            false,
                            episodeIndex,
                            detail.Places[0].VideoLocal_Place_ID,
                            showEpisodeName ? episode.AnimeSeriesID.ToString() : "",
                            episode.EpisodeNumber,
                            showEpisodeName ? episode.AniDB_EnglishName : "",
                            detail.VideoLocal_FileName
                        };
        }
        private void grid1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];// get you required index
                                                         // check the cell value under your specific column and then you can toggle your colors

            if(row.Cells["EpisodeIndex"].Value != null && row.Cells["EpisodeIndex"].Value.GetType() != typeof(DBNull) && Convert.ToInt32(row.Cells["EpisodeIndex"].Value) % 2 == 0)
                row.DefaultCellStyle.BackColor = Color.Green;
        }

        private async Task<Dictionary<ShokoAnimeEpisode, List<ShokoVideoDetailed>>> GetAllVideoDetails()
        {
            var result = new Dictionary<ShokoAnimeEpisode, List<ShokoVideoDetailed>>();

            var allEpisodes = await shokoService.GetAllEpisodesWithMultipleFiles(ShokoService.USER_ID, true, true);
            foreach (var episode in allEpisodes)
            {
                var videoDetailed = await shokoService.GetFilesByGroupAndResolution(ShokoService.USER_ID, episode.AnimeEpisodeID);
                result.Add(episode, videoDetailed);
                //result.Add(episode, new List<ShokoVideoDetailed> { new ShokoVideoDetailed { VideoLocalID = 11, VideoLocal_FileName = "1a" }, new ShokoVideoDetailed { VideoLocalID = 12,  VideoLocal_FileName = "1b" } }); 
            }

            return result;
        }

        private async void removeSelectedBtn_Click(object sender, EventArgs e)
        {
            //TODO: Check Always at least one must be per episode

            List<int> selected = new List<int>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells[0].Value);
                if (isSelected)
                {
                    selected.Add(Convert.ToInt32(row.Cells["VideoLocalPlaceID"].Value));
                }
            }

            foreach (var id in selected)
            {
                await shokoService.DeletePhysicalFile(id);
                Console.WriteLine(id);
            }
        }


    }
}
