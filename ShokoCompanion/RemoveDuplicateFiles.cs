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

            dt.Columns.Add("EpisodeIndex", typeof(int));
            dt.Columns.Add("  ", typeof(bool));
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
                    object[] obj;
                    if (i == 0)
                    {
                        obj = new object[] {
                            episodeIndex,
                            false, 
                            episode.AnimeSeriesID.ToString(), 
                            episode.EpisodeNumber, 
                            episode.AniDB_EnglishName,
                            detail.VideoLocal_FileName
                        };
                    } else
                    {
                        obj = new object[] {
                            episodeIndex,
                            false,
                            "",
                            null,
                            "",
                            detail.VideoLocal_FileName
                        };
                    }
                    dt.Rows.Add(obj);
                }
                episodeIndex++;
                // Coloring rows

            }
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["EpisodeIndex"].Visible = false;
        }

        private void grid1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];// get you required index
                                                         // check the cell value under your specific column and then you can toggle your colors
            if(Convert.ToInt32(row.Cells[0].Value) % 2 == 0)
                row.DefaultCellStyle.BackColor = Color.Green;
        }

        private void removeSelectedBtn_Click(object sender, EventArgs e)
        {
            
        }

        private async Task<Dictionary<ShokoAnimeEpisode, List<ShokoVideoDetailed>>> GetAllVideoDetails()
        {
            var result = new Dictionary<ShokoAnimeEpisode, List<ShokoVideoDetailed>>();

            var allEpisodes = await shokoService.GetAllEpisodesWithMultipleFiles(ShokoService.USER_ID, true, true);
            foreach (var episode in allEpisodes)
            {
                //var videoDetailed = await shokoService.GetFilesByGroupAndResolution(ShokoService.USER_ID, episode.AnimeEpisodeID);
                //result.Add(episode, videoDetailed);
                result.Add(episode, new List<ShokoVideoDetailed> { new ShokoVideoDetailed { VideoLocal_FileName = "1a" }, new ShokoVideoDetailed { VideoLocal_FileName = "1b" } }); 
            }

            return result;
        }



    }
}
