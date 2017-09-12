using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Text_Editor
{
    public partial class findAndReplaceDialog : Form
    {
        private bool mode;      //find mode = true, find and replace = false        
        public bool Mode
        {
            get
            {
                return mode;
            }
            set
            {
                mode = value;
                Changed(this, EventArgs.Empty);
            }
        }
        public event EventHandler Changed;
        public string target;
        public string replacewith;
        public event EventHandler FindClicked;
        public event EventHandler ReplaceClicked;
        public event EventHandler ReplaceAllClicked;
        public void enterFindMode()
        {
            replaceButton.Enabled = false;
            replaceButton.Visible = false;
            replaceTB.Enabled = false;
            replaceTB.Visible = false;
            label2.Visible = false;
            replaceAllButton.Enabled = false;
            replaceAllButton.Visible = false;
            this.AcceptButton = findButton;
        }
        public void enterFindReplaceMode()
        {
            replaceButton.Enabled = true;
            replaceButton.Visible = true;
            replaceTB.Enabled = true;
            replaceTB.Visible = true;
            label2.Visible = true;
            replaceAllButton.Enabled = true;
            replaceAllButton.Visible = true;
            this.AcceptButton = replaceButton;
        }
        public findAndReplaceDialog()
        {
            InitializeComponent();
            mode = true;
            
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            target = findTB.Text;
            FindClicked(this, EventArgs.Empty);
        }

        private void replaceButton_Click(object sender, EventArgs e)
        {
            target = findTB.Text;
            replacewith = replaceTB.Text;
            ReplaceClicked(this, EventArgs.Empty);
        }

        private void replaceAllButton_Click(object sender, EventArgs e)
        {
            target = findTB.Text;
            replacewith = replaceTB.Text;
            ReplaceAllClicked(this, EventArgs.Empty);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
