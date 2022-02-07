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
using System.Windows;
using System.Windows.Forms;

namespace ShokoCompanion
{
    public partial class RemoveDuplicateFiles : Form
    {
        ShokoService shokoService = ShokoService.Instance;
        ShokoFileRemovalService shokoFileRemovalService= ShokoFileRemovalService.Instance;


        public RemoveDuplicateFiles()
        {
            InitializeComponent();
        }

        private async void loadFilesBtn_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            var allVideoDetails = await GetAllVideoDetails();

            dt.Columns.Add(ShokoDataGridColumns.CheckBox, typeof(bool));
            dt.Columns.Add(ShokoDataGridColumns.EpisodeIndex, typeof(int));
            dt.Columns.Add(ShokoDataGridColumns.VideoLocalPlaceID, typeof(int));
            dt.Columns.Add(ShokoDataGridColumns.AnimeName, typeof(string));
            dt.Columns.Add(ShokoDataGridColumns.EpisodeNumber, typeof(int));
            dt.Columns.Add(ShokoDataGridColumns.EpisodeName, typeof(string));
            dt.Columns.Add(ShokoDataGridColumns.Filename, typeof(string));

            var episodeIndex = 0;
            foreach (var episode in allVideoDetails.Keys.OrderBy(c => c.AnimeSeriesID).ThenBy(c => c.EpisodeNumber))
            {
                var details = allVideoDetails[episode];

                for (int i = 0; i < details.Count(); i++)
                {
                    var detail = details[i];
                    dt.Rows.Add(BuildRow(i == 0, episodeIndex, episode, detail, details));
                }
                episodeIndex++;

            }
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[ShokoDataGridColumns.EpisodeIndex].Visible = false;
            dataGridView1.Columns[ShokoDataGridColumns.VideoLocalPlaceID].Visible = false;
        }

        private object[] BuildRow(bool showEpisodeName, int episodeIndex, ShokoAnimeEpisode episode, ShokoVideoDetailed currentDetail, List<ShokoVideoDetailed> episodeDetails)
        {
            return new object[] {
                            shokoFileRemovalService.IsDeleteCandidate(episode, currentDetail, episodeDetails),
                            episodeIndex,
                            currentDetail.Places == null ? 0 : currentDetail.Places[0].VideoLocal_Place_ID,
                            showEpisodeName ? episode.AnimeSeriesID.ToString() : "",
                            episode.EpisodeNumber,
                            showEpisodeName ? episode.AniDB_EnglishName : "",
                            currentDetail.VideoLocal_FileName
                        };
        }
        private void grid1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];// get you required index
                                                         // check the cell value under your specific column and then you can toggle your colors

            var episodeIndexCell = row.Cells[ShokoDataGridColumns.EpisodeIndex];
            if(episodeIndexCell.Value != null && episodeIndexCell.Value.GetType() != typeof(DBNull) && Convert.ToInt32(episodeIndexCell.Value) % 2 == 0)
                row.DefaultCellStyle.BackColor = Color.Green;
        }

        private async Task<Dictionary<ShokoAnimeEpisode, List<ShokoVideoDetailed>>> GetAllVideoDetails()
        {
            var result = new Dictionary<ShokoAnimeEpisode, List<ShokoVideoDetailed>>();

            var allEpisodes = await shokoService.GetAllEpisodesWithMultipleFiles(ShokoService.USER_ID, true, true);
            foreach (var episode in allEpisodes)
            {
                // TODO: Make async
                //var videoDetailed = await shokoService.GetFilesByGroupAndResolution(ShokoService.USER_ID, episode.AnimeEpisodeID);
                //result.Add(episode, videoDetailed);
                result.Add(episode, new List<ShokoVideoDetailed> { new ShokoVideoDetailed { VideoLocalID = 11, VideoLocal_FileName = "1a" }, new ShokoVideoDetailed { VideoLocalID = 12,  VideoLocal_FileName = "1b" } }); 
            }

            return result;
        }

        private async void removeSelectedBtn_Click(object sender, EventArgs e)
        {
            //TODO: Check Always at least one must be per episode
            List<int> selected = new List<int>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells[ShokoDataGridColumns.CheckBoxIndex].Value);
                if (isSelected)
                {
                    selected.Add(Convert.ToInt32(row.Cells[ShokoDataGridColumns.VideoLocalPlaceID].Value));
                }
            }

            MessageBoxResult confirmResult = System.Windows.MessageBox.Show($"Are you sure to delete {selected.Count} items?", "Confirm Deletetion!!", MessageBoxButton.YesNo);

            if (confirmResult == MessageBoxResult.Yes)
            {
                foreach (var id in selected)
                {
                    //await shokoService.DeletePhysicalFile(id);
                    Console.WriteLine(id);
                }
            }
        }

        private bool _allSelected = false;
        private void toggleSelectedBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[ShokoDataGridColumns.CheckBoxIndex];
                    chk.Value = !_allSelected;
            }
            _allSelected = !_allSelected;
        }
    }
}
