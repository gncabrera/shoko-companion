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
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void removeDuplicateFilesBtn_Click(object sender, EventArgs e)
        {
            var f = new RemoveDuplicateFiles();
            f.ShowDialog();
        }
    }
}
