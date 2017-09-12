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
    public partial class ThemeDialog : Form
    {
        public class Styles
        {
            public const int None = 0;
            public const int Fixed = 1;
            public const int Sizable = 2;
        }
        public int radioButtons;
        public int windowColorSelected;
        public class windowColors
        {
            public const int Default = 0;
            public const int LightBlue = 1;
            public const int LightGreen = 2;
        }
        /*
        public int textColorSelected;
        public class textColors
        {            
            public const int Black = 0;
            public const int Red = 1;
            public const int Blue = 2;
            public const int Green = 3;
        }*/

        public ThemeDialog()
        {
            InitializeComponent();
            noneRB.Checked = false;
            fixedRB.Checked = false;
            sizableRB.Checked = true;
            windowColorsLB.SelectedIndex = 0;
            //textColorsLB.SelectedIndex = 0;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (noneRB.Checked) { radioButtons = Styles.None; }
            if (fixedRB.Checked) { radioButtons = Styles.Fixed; }
            if (sizableRB.Checked) { radioButtons = Styles.Sizable; }
            windowColorSelected = windowColorsLB.SelectedIndex;
            //textColorSelected = textColorsLB.SelectedIndex;
            this.DialogResult = DialogResult.OK;
        }

        private void cancenButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
