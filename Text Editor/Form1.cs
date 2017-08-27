using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Text_Editor
{
    public partial class Form1 : Form
    {
        string filename = "";  //used to hold the filename returned from save As dialog
        ThemeDialog themeDialog1 = new ThemeDialog();
        findAndReplaceDialog frdialog1 = new findAndReplaceDialog();

        public Form1()
        {
            InitializeComponent();
            dataRTB.WordWrap = true;
            wordWrapMenuItem.CheckState = CheckState.Checked;
            frdialog1.Changed += new EventHandler(modeChanged);     //registering my event handler
            frdialog1.FindClicked += new EventHandler(findclicked);
            frdialog1.ReplaceClicked += new EventHandler(replaceclicked);
        }

        private void openMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileDialog1.ShowReadOnly = false;
                filename = openFileDialog1.FileName;
                Form1.ActiveForm.Text = openFileDialog1.SafeFileName;
                saveMenuItem.Enabled = true;
                StreamReader sr;
                try
                {
                    sr = new StreamReader(File.OpenRead(filename));
                }
                catch (PathTooLongException ex)
                {
                    MessageBox.Show("Failed to open " + filename + ":  " + ex.Message);
                    return;
                }
                catch (DirectoryNotFoundException ex)
                {
                    MessageBox.Show("Failed to open " + filename + ":  " + ex.Message);
                    return;
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show("Failed to open " + filename + ":  " + ex.Message);
                    return;
                }
                catch (FileNotFoundException ex)
                {
                    MessageBox.Show("Failed to open " + filename + ":  " + ex.Message);
                    return;
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Failed to open " + filename + ":  " + ex.Message);
                    return;
                }
                //if we are here, the file is open

                string line = "";
                while (!sr.EndOfStream)
                {

                    try
                    {
                        line += sr.ReadLine() + "\r\n";
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("Failed to read " + filename + ":  " + ex.Message);
                        break;
                    }
                    catch (OutOfMemoryException ex)
                    {
                        MessageBox.Show("Failed to read " + filename + ":  " + ex.Message);
                        break;
                    }

                }
                dataRTB.Text = line;
                sr.Close();
            }


        }
        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            if (filename.Length != 0)
            {
                //filename is not empty, so it should work.
                StreamWriter sw;
                try
                {
                    sw = new StreamWriter(File.OpenWrite(filename));
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show("Failed to save file:  " + ex.Message);
                    return;
                }
                catch (DirectoryNotFoundException ex)
                {
                    MessageBox.Show("Failed to save file:  " + ex.Message);
                    return;
                }
                catch (PathTooLongException ex)
                {
                    MessageBox.Show("Failed to save file:  " + ex.Message);
                    return;
                }
                //if we made it here, the file is open
                foreach (string line in dataRTB.Lines)
                {
                    try
                    {
                        sw.WriteLine(line);
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("Failed to save file:  " + ex.Message);
                        break;
                    }
                    catch (ObjectDisposedException ex)
                    {
                        MessageBox.Show("Failed to save file:  " + ex.Message);
                        break;
                    }

                }
                //If we are here, we either saved our data or not, but we need to close the file.
                try
                {
                    sw.Close();
                }
                catch (EncoderFallbackException ex)
                {
                    MessageBox.Show("Failed to save file:  " + ex.Message);
                }
            }
            else
            {
                //filename == ""
                //This shouldn't happen, but if it does, make sure it doesn't happen again.
                saveAsMenuItem.Enabled = false;
            }
        }

        private void saveAsMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = saveFileDialog1.FileName;                
                string s = filename.Substring(filename.LastIndexOf('\\') + 1);  //pull just the file name from the path
                Form1.ActiveForm.Text = s;
                saveMenuItem.Enabled = true;
                saveMenuItem_Click(sender, e);
            }
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {           String text = "";
            String author = "Author:  James A. Stewart";
            string classname = "Web Development Boot Camp";
            string version = Application.ProductVersion;
            text = Application.ProductName + "\r\n" + version + "\r\n" +
                    classname + "\r\n" + author;
            MessageBox.Show(text);
        }

        private void wordWrapMenuItem_Click(object sender, EventArgs e)
        {
            switch (wordWrapMenuItem.Checked)
            {
                case true:
                    wordWrapMenuItem.Checked = false;
                    dataRTB.WordWrap = false;
                    dataRTB.ScrollBars = RichTextBoxScrollBars.Both;
                    break;
                case false:
                    wordWrapMenuItem.Checked = true;
                    dataRTB.WordWrap = true;
                    dataRTB.ScrollBars = RichTextBoxScrollBars.Vertical;
                    break;
            }
        }

        /*private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            int i = (int)Form1.ActiveForm.FormBorderStyle;
            i = (i + 1) % 7;
            
            //MessageBox.Show("About to use value " + i);
            if (Form1.ActiveForm != null)//it shouldn't be, but this keeps happening in debug mode
            {
                Form1.ActiveForm.FormBorderStyle = (FormBorderStyle)i;
            }
            //CommonDialog d = new CommonDialog();
        }*/

        private void themeMenuItem_Click(object sender, EventArgs e)
        {
            //ThemeDialog themedialog1 = new ThemeDialog();
            if (themeDialog1.ShowDialog() == DialogResult.OK)
            {
                switch (themeDialog1.radioButtons)
                {
                    case ThemeDialog.Styles.None:
                        Form1.ActiveForm.FormBorderStyle = (FormBorderStyle)0;
                        break;
                    case ThemeDialog.Styles.Fixed:
                        Form1.ActiveForm.FormBorderStyle = (FormBorderStyle)2;
                        break;
                    case ThemeDialog.Styles.Sizable:
                        //Form1.ActiveForm.FormBorderStyle = (FormBorderStyle)2;
                        Form1.ActiveForm.FormBorderStyle = (FormBorderStyle)4;
                        //Form1.ActiveForm.ShowIcon = true;
                        //Form1.ActiveForm.Refresh();
                        break;
                }
                switch (themeDialog1.windowColorSelected)
                {
                    
                    case ThemeDialog.windowColors.Default:
                        Form1.ActiveForm.BackColor = Form1.DefaultBackColor;
                        dataRTB.BackColor = System.Drawing.Color.White;
                        break;
                    case ThemeDialog.windowColors.LightBlue:
                        Form1.ActiveForm.BackColor = System.Drawing.Color.LightBlue;
                        dataRTB.BackColor = System.Drawing.Color.LightBlue;
                        break;
                    case ThemeDialog.windowColors.LightGreen:
                        Form1.ActiveForm.BackColor = System.Drawing.Color.LightGreen;
                        dataRTB.BackColor = System.Drawing.Color.LightGreen;
                        break;
                }
                switch (themeDialog1.textColorSelected)
                {
                    case ThemeDialog.textColors.Black:
                        Form1.ActiveForm.ForeColor = System.Drawing.Color.Black;
                        dataRTB.ForeColor = System.Drawing.Color.Black;
                        break;
                    case ThemeDialog.textColors.Red:
                        Form1.ActiveForm.ForeColor = System.Drawing.Color.Red;
                        dataRTB.ForeColor = System.Drawing.Color.Red;
                        break;
                    case ThemeDialog.textColors.Blue:
                        Form1.ActiveForm.ForeColor = System.Drawing.Color.Blue;
                        dataRTB.ForeColor = System.Drawing.Color.Blue;
                        break;
                    case ThemeDialog.textColors.Green:
                        Form1.ActiveForm.ForeColor = System.Drawing.Color.Green;
                        dataRTB.ForeColor = System.Drawing.Color.Green;
                        break;
                }
            }

        }

        

        private void fontMenuItem_Click_1(object sender, EventArgs e)
        {
            fontDialog1.ShowColor = true;
            DialogResult dr = fontDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {               
            dataRTB.Font = fontDialog1.Font;
                dataRTB.ForeColor = fontDialog1.Color;
            }
        }

        private void findMenuItem_Click(object sender, EventArgs e)
        {
            frdialog1.Mode = true;  //I setup a event handler to react to Mode being changed.
            frdialog1.Show();
        }

        private void findAndReplceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frdialog1.Mode = false;            
            frdialog1.Show();
        }

        void modeChanged (object sender, EventArgs e)   //this gets called whenever Mode is changed.
        {
            findAndReplaceDialog d = (findAndReplaceDialog)sender;
            if (d.Mode == true)
            {
                //going into Find mode
                frdialog1.enterFindMode();

            }
            else
            {
                //going into Find and Replace mode
                frdialog1.enterFindReplaceMode();
            }
        }

        void findclicked(object sender, EventArgs e)
        {
            string target = frdialog1.target;
            if (dataRTB.Text.Length > 0)    //if the textbox is not empty
            {
                if (dataRTB.Text.Contains(target))  //if the target is int the textbox
                {
                    int index = dataRTB.Text.IndexOf(target);
                    dataRTB.Select(index, 0);
                    dataRTB.Focus();
                } else
                {
                    MessageBox.Show(target + " is not in this document.");
                }
            }
        }

        void replaceclicked (object sender, EventArgs e)
        {
            string target = frdialog1.target;
            int l = target.Length;
            string with = frdialog1.replacewith;
            if (with.Length > 0)            //if there is a replace string
            {
                if (dataRTB.Text.Length > 0)    //if the textbox is not empty
                {
                    if (dataRTB.Text.Contains(target))  //if the target is int the textbox
                    {
                        int index = dataRTB.Text.IndexOf(target);
                        dataRTB.Select(index, l);
                        dataRTB.SelectedText = with;
                        dataRTB.Focus();
                    }
                    else
                    {
                        MessageBox.Show(target + " is not in this document.");
                    }
                }
            }
        }
    } 
}
