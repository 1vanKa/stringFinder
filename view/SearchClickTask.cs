using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab4.controller;

namespace Lab4.view
{
    class SearchClickTask
    {
        private readonly RichTextBox richTextBox;
        private readonly Task task;

        private readonly String find;
        private readonly String source;

        public SearchClickTask(RichTextBox richTextBox, TextBox searchTextBox)
        {
            this.richTextBox = richTextBox;
            find = searchTextBox.Text;
            source = richTextBox.Text;
            task = new Task(Run);
        }

        public void Run()
        {
            List<int> foundPos = StringSearchController.Search(source, find);
            richTextBox.BeginInvoke(new Action(() =>
            {
                richTextBox.SelectAll();
                richTextBox.SelectionBackColor = System.Drawing.Color.White;
                if (foundPos != null)
                    lock (foundPos)
                        foreach (int i in foundPos)
                        {
                            richTextBox.Select(i, find.Length);
                            richTextBox.SelectionBackColor = System.Drawing.Color.Yellow;
                        }
            }));
        }

        public void Start()
        {
            task.Start();
        }
    }
}
