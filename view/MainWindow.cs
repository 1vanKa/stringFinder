using System;
using System.IO;
using System.Threading.Tasks;
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

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog(this);
            String path = openFileDialog.FileName;
            if (String.IsNullOrEmpty(path))
            {
                return;
            }

            Task task = new Task(() =>
            {
                String[] sourceLines = File.ReadAllLines(path);
                String source = "";
                foreach (var s in sourceLines)
                {
                    source += s;
                }
                richTextBox.Invoke(new Action(() => richTextBox.Text = source));
            });
            task.Start();
        }
    }
}
