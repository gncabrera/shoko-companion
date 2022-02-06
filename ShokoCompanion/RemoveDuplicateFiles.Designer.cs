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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // loadFilesBtn
            // 
            this.loadFilesBtn.Location = new System.Drawing.Point(13, 13);
            this.loadFilesBtn.Name = "loadFilesBtn";
            this.loadFilesBtn.Size = new System.Drawing.Size(75, 23);
            this.loadFilesBtn.TabIndex = 0;
            this.loadFilesBtn.Text = "Load Files";
            this.loadFilesBtn.UseVisualStyleBackColor = true;
            this.loadFilesBtn.Click += new System.EventHandler(this.loadFilesBtn_Click);
            // 
            // removeSelectedBtn
            // 
            this.removeSelectedBtn.Location = new System.Drawing.Point(94, 13);
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 42);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 396);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(grid1_CellFormatting);

            // 
            // RemoveDuplicateFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.removeSelectedBtn);
            this.Controls.Add(this.loadFilesBtn);
            this.Name = "RemoveDuplicateFiles";
            this.Text = "RemoveDuplicateFiles";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        

        #endregion

        private System.Windows.Forms.Button loadFilesBtn;
        private System.Windows.Forms.Button removeSelectedBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}