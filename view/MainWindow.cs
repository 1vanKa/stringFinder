using System;
using System.Windows.Forms;

namespace Lab4.view
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog(this);
            String path = openFileDialog.FileName;
            throw new System.NotImplementedException();
        }
    }
}
