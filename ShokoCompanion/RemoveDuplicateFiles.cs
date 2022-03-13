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
        private Dictionary<ShokoAnimeEpisode, List<ShokoVideoDetailed>> Episodes { get; set; }


        public RemoveDuplicateFiles()
        {
            InitializeComponent();
            lblProgress.Text = "";
            totalItemsLbl.Text = "0 episodes / 0 items / 0 selected";
            Episodes = new Dictionary<ShokoAnimeEpisode, List<ShokoVideoDetailed>>();
        }

        private void LoadingStart()
        {
            loadFilesBtn.Enabled = false;
            toggleSelectedBtn.Enabled = false;
            removeSelectedBtn.Enabled=false;
            dataGridView1.Enabled = false;
            chkOnlyFinishedSeries.Enabled = false;
        }

        private void LoadingStop()
        {
            loadFilesBtn.Enabled = true;
            toggleSelectedBtn.Enabled = true;
            removeSelectedBtn.Enabled = true;
            dataGridView1.Enabled = true;
            chkOnlyFinishedSeries.Enabled = true;
        }

        private void UpdateProgressBar(string label, int value)
        {
            progressBar1.Value = value;
            lblProgress.Text = label;
        }

        private async void loadFilesBtn_Click(object sender, EventArgs e)
        {
            LoadingStart();

            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            DataTable dt = new DataTable();

            var allVideoDetails = await GetAllVideoDetails(chkOnlyFinishedSeries.Checked);

            dt.Columns.Add(ShokoDataGridColumns.CheckBox, typeof(bool));
            dt.Columns.Add(ShokoDataGridColumns.EpisodeIndex, typeof(int));
            dt.Columns.Add(ShokoDataGridColumns.VideoLocalPlaceID, typeof(int));
            dt.Columns.Add(ShokoDataGridColumns.AnimeName, typeof(string));
            dt.Columns.Add(ShokoDataGridColumns.EpisodeNumber, typeof(int));
            dt.Columns.Add(ShokoDataGridColumns.EpisodeName, typeof(string));
            dt.Columns.Add(ShokoDataGridColumns.FileVersion, typeof(string));
            dt.Columns.Add(ShokoDataGridColumns.GroupName, typeof(string));
            dt.Columns.Add(ShokoDataGridColumns.Filename, typeof(string));

            var episodeIndex = 0;
            var orderedDetails = allVideoDetails.Keys
                .OrderBy(c => c.AnimeSeriesID)
                .ThenBy(c => c.EpisodeNumber);

            foreach (var episode in orderedDetails)
            {
                var details = allVideoDetails[episode].OrderBy(d => d.AniDB_Anime_GroupName).ThenBy(d => d.AniDB_File_FileVersion);

                for (int i = 0; i < details.Count(); i++)
                {
                    var detail = details.ElementAt(i);
                    dt.Rows.Add(BuildRow(i == 0, episodeIndex, episode, detail, details));
                }
                episodeIndex++;

            }

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            dataGridView1.DataSource = dt;
            dataGridView1.Columns[ShokoDataGridColumns.CheckBox].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[ShokoDataGridColumns.EpisodeIndex].Visible = false;
            dataGridView1.Columns[ShokoDataGridColumns.VideoLocalPlaceID].Visible = false;
            dataGridView1.Columns[ShokoDataGridColumns.AnimeName].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[ShokoDataGridColumns.EpisodeNumber].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[ShokoDataGridColumns.EpisodeNumber].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; ;
            dataGridView1.Columns[ShokoDataGridColumns.EpisodeNumber].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[ShokoDataGridColumns.EpisodeName].Width = 200;
            dataGridView1.Columns[ShokoDataGridColumns.FileVersion].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[ShokoDataGridColumns.FileVersion].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; ;
            dataGridView1.Columns[ShokoDataGridColumns.FileVersion].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[ShokoDataGridColumns.GroupName].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[ShokoDataGridColumns.Filename].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            // Making Read Only all cells!
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach(DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex != ShokoDataGridColumns.CheckBoxIndex)
                    cell.ReadOnly = true;
                }
            }

            UpdateTotalItemsLabel();
            LoadingStop();
            UpdateProgressBar("Done! Start killing files!", 100);

        }

        private object[] BuildRow(bool showEpisodeName, int episodeIndex, ShokoAnimeEpisode episode, ShokoVideoDetailed currentDetail, IEnumerable<ShokoVideoDetailed> episodeDetails)
        {
            return new object[] {
                            shokoFileRemovalService.IsDeleteCandidate(episode, currentDetail, episodeDetails), // Checkbox
                            episodeIndex,   //EpisodeIndex
                            currentDetail.Places == null ? 0 : currentDetail.Places[0].VideoLocal_Place_ID, // VideoLocalPlaceID
                            showEpisodeName ? episode.AnimeSeriesID.ToString() : "", // AnimeName
                            episode.EpisodeNumber, // EpisodeNumber
                            showEpisodeName ? episode.AniDB_EnglishName : "", // EpisodeName
                            currentDetail.AniDB_File_FileVersion, // FileVersion
                            currentDetail.AniDB_Anime_GroupName, // GroupName
                            currentDetail.VideoLocal_FileName // Filename
                        };
        }
        private void grid1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];// get you required index
                                                         // check the cell value under your specific column and then you can toggle your colors

            var episodeIndexCell = row.Cells[ShokoDataGridColumns.EpisodeIndex];
            if(episodeIndexCell.Value != null && episodeIndexCell.Value.GetType() != typeof(DBNull) && Convert.ToInt32(episodeIndexCell.Value) % 2 == 0)
                row.DefaultCellStyle.BackColor = Color.FromArgb(unchecked((int)0xFFFEF8D7));
        }

        private async Task<Dictionary<ShokoAnimeEpisode, List<ShokoVideoDetailed>>> GetAllVideoDetails(bool onlyFinishedSeries = true, bool ignoreVariations = true)
        {
            var finalProgressPercentage = 99;
            UpdateProgressBar("Loading Video Duplicated Videos...", 0);
            Episodes = new Dictionary<ShokoAnimeEpisode, List<ShokoVideoDetailed>>();

            int progressCounter = 0;
            var allEpisodes = await shokoService.GetAllEpisodesWithMultipleFiles(ShokoService.USER_ID, onlyFinishedSeries, ignoreVariations);
            foreach (var episode in allEpisodes)
            {
                progressCounter++;
                UpdateProgressBar($"Loading Video Details {progressCounter}/{allEpisodes.Count}", progressCounter * finalProgressPercentage / allEpisodes.Count);
                var videoDetailed = await shokoService.GetFilesByGroupAndResolution(ShokoService.USER_ID, episode.AnimeEpisodeID);
                Episodes.Add(episode, videoDetailed);
            }
            
            UpdateProgressBar("Wrapping up...", finalProgressPercentage);

            return Episodes;
        }

        private List<int> GetSelectedFileIds()
        {
            List<int> selected = new List<int>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells[ShokoDataGridColumns.CheckBoxIndex].Value);
                if (isSelected)
                {
                    selected.Add(Convert.ToInt32(row.Cells[ShokoDataGridColumns.VideoLocalPlaceID].Value));
                }
            }
            return selected;
        }
        private async void removeSelectedBtn_Click(object sender, EventArgs e)
        {
            //TODO: Check Always at least one must be per episode

            var selected = GetSelectedFileIds();
            MessageBoxResult confirmResult = System.Windows.MessageBox.Show($"Are you sure to delete {selected.Count} items?", "Confirm Deletion!!", MessageBoxButton.YesNo);

            if (confirmResult == MessageBoxResult.Yes)
            {
                LoadingStart();
                UpdateProgressBar("", 0);

                
                var progressCounter = 0;
                foreach (var id in selected)
                {
                    progressCounter++;
                    UpdateProgressBar($"Removing file {progressCounter}/{selected.Count}", progressCounter * 100 / selected.Count);

                    await Task.Delay(500);
                    await shokoService.DeletePhysicalFile(id);
                    Console.WriteLine(id);
                }

                UpdateProgressBar("All files Deleted! Load everything again!", 100);
                LoadingStop();
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

        private void UpdateTotalItemsLabel()
        {
            this.totalItemsLbl.Text = $"{Episodes.Keys.Count} episodes / {dataGridView1.Rows.Count} items / {GetSelectedFileIds().Count} selected";
        }

        private void myDataGrid_OnCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ShokoDataGridColumns.CheckBoxIndex && e.RowIndex != -1)
            {
                UpdateTotalItemsLabel();
            }
        }

        private void myDataGrid_OnCellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            // End of edition on each click on column of checkbox
            if (e.ColumnIndex == ShokoDataGridColumns.CheckBoxIndex && e.RowIndex != -1)
            {
                dataGridView1.EndEdit();
            }
        }

        private void myDataGrid_OnCellDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Toggle checkbox on double click
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[ShokoDataGridColumns.CheckBoxIndex];
            chk.Value = !Convert.ToBoolean(chk.Value);

            row.Cells[ShokoDataGridColumns.CheckBoxIndex].Selected = !row.Cells[ShokoDataGridColumns.CheckBoxIndex].Selected;
            UpdateTotalItemsLabel();
        }

    }
}
