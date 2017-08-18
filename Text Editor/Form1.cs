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

        public Form1()
        {
            InitializeComponent();
        }

        private void openMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileDialog1.ShowReadOnly = false;
                filename = openFileDialog1.FileName;
                saveMenuItem.Enabled = true;
                StreamReader sr;
                try
                {
                    sr = new StreamReader(File.OpenRead(filename));
                }catch (PathTooLongException ex)
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

                string line="";
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
                } catch (UnauthorizedAccessException ex)
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
                try
                {
                    sw.Write(dataRTB.Text);
                } catch (IOException ex)
                {
                    MessageBox.Show("Failed to save file:  " + ex.Message);
                }
                catch (ObjectDisposedException ex)
                {
                    MessageBox.Show("Failed to save file:  " + ex.Message);
                }
                //If we are here, we either saved our data or not, but we need to close the file.
                try
                {
                    sw.Close();
                } catch (EncoderFallbackException ex)
                {
                    MessageBox.Show("Failed to save file:  " + ex.Message);
                }
            }
            else
            {
                //This shouldn't happen, but if it does, make sure it doesn't happen again.
                saveAsMenuItem.Enabled = false;
            }
        }

        private void saveAsMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = saveFileDialog1.FileName;
                saveMenuItem.Enabled = true;
                saveMenuItem_Click(sender, e);
            }
        }
    }
}
