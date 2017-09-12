namespace Text_Editor
{
    partial class ThemeDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.noneRB = new System.Windows.Forms.RadioButton();
            this.fixedRB = new System.Windows.Forms.RadioButton();
            this.sizableRB = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancenButton = new System.Windows.Forms.Button();
            this.windowColorsLB = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // noneRB
            // 
            this.noneRB.AutoSize = true;
            this.noneRB.Location = new System.Drawing.Point(37, 82);
            this.noneRB.Name = "noneRB";
            this.noneRB.Size = new System.Drawing.Size(51, 17);
            this.noneRB.TabIndex = 2;
            this.noneRB.Text = "None";
            this.noneRB.UseVisualStyleBackColor = true;
            // 
            // fixedRB
            // 
            this.fixedRB.AutoSize = true;
            this.fixedRB.Location = new System.Drawing.Point(37, 59);
            this.fixedRB.Name = "fixedRB";
            this.fixedRB.Size = new System.Drawing.Size(50, 17);
            this.fixedRB.TabIndex = 1;
            this.fixedRB.Text = "Fixed";
            this.fixedRB.UseVisualStyleBackColor = true;
            // 
            // sizableRB
            // 
            this.sizableRB.AutoSize = true;
            this.sizableRB.Checked = true;
            this.sizableRB.Location = new System.Drawing.Point(36, 36);
            this.sizableRB.Name = "sizableRB";
            this.sizableRB.Size = new System.Drawing.Size(100, 17);
            this.sizableRB.TabIndex = 0;
            this.sizableRB.TabStop = true;
            this.sizableRB.Text = "Sizable (default)";
            this.sizableRB.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Window border style";
            // 
            // okButton
            // 
            this.okButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okButton.Location = new System.Drawing.Point(36, 273);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 27);
            this.okButton.TabIndex = 8;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancenButton
            // 
            this.cancenButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancenButton.Location = new System.Drawing.Point(219, 273);
            this.cancenButton.Name = "cancenButton";
            this.cancenButton.Size = new System.Drawing.Size(75, 27);
            this.cancenButton.TabIndex = 9;
            this.cancenButton.Text = "Cancel";
            this.cancenButton.UseVisualStyleBackColor = true;
            this.cancenButton.Click += new System.EventHandler(this.cancenButton_Click);
            // 
            // windowColorsLB
            // 
            this.windowColorsLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowColorsLB.FormattingEnabled = true;
            this.windowColorsLB.ItemHeight = 16;
            this.windowColorsLB.Items.AddRange(new object[] {
            "Default",
            "Light Blue",
            "Light Green"});
            this.windowColorsLB.Location = new System.Drawing.Point(36, 161);
            this.windowColorsLB.Name = "windowColorsLB";
            this.windowColorsLB.Size = new System.Drawing.Size(120, 52);
            this.windowColorsLB.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Window color";
            // 
            // ThemeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 312);
            this.Controls.Add(this.cancenButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.windowColorsLB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sizableRB);
            this.Controls.Add(this.fixedRB);
            this.Controls.Add(this.noneRB);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ThemeDialog";
            this.Text = "Window Style";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton noneRB;
        private System.Windows.Forms.RadioButton fixedRB;
        private System.Windows.Forms.RadioButton sizableRB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancenButton;
        private System.Windows.Forms.ListBox windowColorsLB;
        private System.Windows.Forms.Label label2;
    }
}