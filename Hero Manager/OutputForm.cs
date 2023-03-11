using System;
using System.Windows.Forms;

namespace Hero_Manager
{
    public partial class OutputForm : Form
    {
        public OutputForm(string title)
        {
            InitializeComponent();
            this.Text = title;
            this.tbOut.Text = String.Empty;
        }

        public void AddLine(string line)
        {
            this.tbOut.Text = this.tbOut.Text + line + Environment.NewLine;
        }
    }
}
