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
            this.totalItemsLbl = new System.Windows.Forms.Label();
            this.toggleSelectedBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // loadFilesBtn
            // 
            this.loadFilesBtn.Location = new System.Drawing.Point(3, 12);
            this.loadFilesBtn.Name = "loadFilesBtn";
            this.loadFilesBtn.Size = new System.Drawing.Size(75, 23);
            this.loadFilesBtn.TabIndex = 0;
            this.loadFilesBtn.Text = "Load Files";
            this.loadFilesBtn.UseVisualStyleBackColor = true;
            this.loadFilesBtn.Click += new System.EventHandler(this.loadFilesBtn_Click);
            // 
            // removeSelectedBtn
            // 
            this.removeSelectedBtn.Location = new System.Drawing.Point(186, 12);
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
            this.dataGridView1.Location = new System.Drawing.Point(0, 44);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1213, 600);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.myDataGrid_OnCellDoubleClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grid1_CellFormatting);
            this.dataGridView1.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.myDataGrid_OnCellMouseUp);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.myDataGrid_OnCellValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.totalItemsLbl);
            this.panel1.Controls.Add(this.toggleSelectedBtn);
            this.panel1.Controls.Add(this.loadFilesBtn);
            this.panel1.Controls.Add(this.removeSelectedBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1213, 44);
            this.panel1.TabIndex = 3;
            // 
            // totalItemsLbl
            // 
            this.totalItemsLbl.AutoSize = true;
            this.totalItemsLbl.Location = new System.Drawing.Point(303, 17);
            this.totalItemsLbl.Name = "totalItemsLbl";
            this.totalItemsLbl.Size = new System.Drawing.Size(100, 13);
            this.totalItemsLbl.TabIndex = 3;
            this.totalItemsLbl.Text = "0 items / 0 selected";
            // 
            // toggleSelectedBtn
            // 
            this.toggleSelectedBtn.Location = new System.Drawing.Point(84, 12);
            this.toggleSelectedBtn.Name = "toggleSelectedBtn";
            this.toggleSelectedBtn.Size = new System.Drawing.Size(96, 23);
            this.toggleSelectedBtn.TabIndex = 2;
            this.toggleSelectedBtn.Text = "Toggle Selected";
            this.toggleSelectedBtn.UseVisualStyleBackColor = true;
            this.toggleSelectedBtn.Click += new System.EventHandler(this.toggleSelectedBtn_Click);
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
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        

        #endregion

        private System.Windows.Forms.Button loadFilesBtn;
        private System.Windows.Forms.Button removeSelectedBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Panel panel1;
        private Button toggleSelectedBtn;
        private Label totalItemsLbl;


    }
}