using System;
using System.Windows.Forms;

namespace ShokoCompanion
{
    partial class RemoveDuplicateFiles
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.loadFilesBtn = new System.Windows.Forms.Button();
            this.removeSelectedBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblProgress = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.toggleSelectedBtn = new System.Windows.Forms.Button();
            this.totalItemsLbl = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkOnlyFinishedSeries = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // loadFilesBtn
            // 
            this.loadFilesBtn.Location = new System.Drawing.Point(8, 22);
            this.loadFilesBtn.Name = "loadFilesBtn";
            this.loadFilesBtn.Size = new System.Drawing.Size(75, 23);
            this.loadFilesBtn.TabIndex = 0;
            this.loadFilesBtn.Text = "Load Files";
            this.loadFilesBtn.UseVisualStyleBackColor = true;
            this.loadFilesBtn.Click += new System.EventHandler(this.loadFilesBtn_Click);
            // 
            // removeSelectedBtn
            // 
            this.removeSelectedBtn.Location = new System.Drawing.Point(108, 22);
            this.removeSelectedBtn.Name = "removeSelectedBtn";
            this.removeSelectedBtn.Size = new System.Drawing.Size(111, 23);
            this.removeSelectedBtn.TabIndex = 1;
            this.removeSelectedBtn.Text = "Remove Selected";
            this.removeSelectedBtn.UseVisualStyleBackColor = true;
            this.removeSelectedBtn.Click += new System.EventHandler(this.removeSelectedBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 84);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1213, 560);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grid1_CellFormatting);
            this.dataGridView1.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.myDataGrid_OnCellMouseUp);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.myDataGrid_OnCellValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1213, 84);
            this.panel1.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblProgress);
            this.groupBox3.Controls.Add(this.progressBar1);
            this.groupBox3.Location = new System.Drawing.Point(465, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(249, 77);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Progress";
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(7, 51);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(10, 13);
            this.lblProgress.TabIndex = 7;
            this.lblProgress.Text = "-";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 22);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(237, 23);
            this.progressBar1.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.toggleSelectedBtn);
            this.groupBox2.Controls.Add(this.removeSelectedBtn);
            this.groupBox2.Controls.Add(this.totalItemsLbl);
            this.groupBox2.Location = new System.Drawing.Point(210, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(249, 77);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Remove";
            // 
            // toggleSelectedBtn
            // 
            this.toggleSelectedBtn.Location = new System.Drawing.Point(6, 22);
            this.toggleSelectedBtn.Name = "toggleSelectedBtn";
            this.toggleSelectedBtn.Size = new System.Drawing.Size(96, 23);
            this.toggleSelectedBtn.TabIndex = 2;
            this.toggleSelectedBtn.Text = "Toggle Selected";
            this.toggleSelectedBtn.UseVisualStyleBackColor = true;
            this.toggleSelectedBtn.Click += new System.EventHandler(this.toggleSelectedBtn_Click);
            // 
            // totalItemsLbl
            // 
            this.totalItemsLbl.AutoSize = true;
            this.totalItemsLbl.Location = new System.Drawing.Point(6, 52);
            this.totalItemsLbl.Name = "totalItemsLbl";
            this.totalItemsLbl.Size = new System.Drawing.Size(100, 13);
            this.totalItemsLbl.TabIndex = 3;
            this.totalItemsLbl.Text = "0 items / 0 selected";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkOnlyFinishedSeries);
            this.groupBox1.Controls.Add(this.loadFilesBtn);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 77);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Load Data";
            // 
            // chkOnlyFinishedSeries
            // 
            this.chkOnlyFinishedSeries.AutoSize = true;
            this.chkOnlyFinishedSeries.Checked = true;
            this.chkOnlyFinishedSeries.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOnlyFinishedSeries.Location = new System.Drawing.Point(8, 51);
            this.chkOnlyFinishedSeries.Name = "chkOnlyFinishedSeries";
            this.chkOnlyFinishedSeries.Size = new System.Drawing.Size(116, 17);
            this.chkOnlyFinishedSeries.TabIndex = 5;
            this.chkOnlyFinishedSeries.Text = "Only finished series";
            this.chkOnlyFinishedSeries.UseVisualStyleBackColor = true;
            // 
            // RemoveDuplicateFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 644);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "RemoveDuplicateFiles";
            this.Text = "RemoveDuplicateFiles";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        

        #endregion

        private System.Windows.Forms.Button loadFilesBtn;
        private System.Windows.Forms.Button removeSelectedBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Panel panel1;
        private Button toggleSelectedBtn;
        private Label totalItemsLbl;
        private GroupBox groupBox1;
        private CheckBox chkOnlyFinishedSeries;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private ProgressBar progressBar1;
        private Label lblProgress;
    }
}