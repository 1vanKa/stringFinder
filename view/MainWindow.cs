using Lab4.controller;
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

        private void SearchButton_Click(object sender, EventArgs e)
        {
            SearchClickTask t = new SearchClickTask(richTextBox, searchTextBox);
            t.Start();
        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog(this);
            String path = openFileDialog.FileName;
            if (String.IsNullOrEmpty(path)) 
                return;

            throw new System.NotImplementedException();
        }
    }
}
