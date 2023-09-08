namespace Hero_Manager
{
    partial class SkillExplorer
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
            lbSkills = new System.Windows.Forms.ListBox();
            label1 = new System.Windows.Forms.Label();
            tbOutput = new System.Windows.Forms.TextBox();
            tbFilter = new System.Windows.Forms.TextBox();
            button1 = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // lbSkills
            // 
            lbSkills.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lbSkills.FormattingEnabled = true;
            lbSkills.ItemHeight = 30;
            lbSkills.Location = new System.Drawing.Point(12, 42);
            lbSkills.Name = "lbSkills";
            lbSkills.Size = new System.Drawing.Size(520, 1024);
            lbSkills.TabIndex = 0;
            lbSkills.SelectedIndexChanged += lbSkills_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(63, 30);
            label1.TabIndex = 1;
            label1.Text = "Skills:";
            // 
            // tbOutput
            // 
            tbOutput.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbOutput.Location = new System.Drawing.Point(538, 42);
            tbOutput.Multiline = true;
            tbOutput.Name = "tbOutput";
            tbOutput.ReadOnly = true;
            tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            tbOutput.Size = new System.Drawing.Size(1697, 1072);
            tbOutput.TabIndex = 2;
            // 
            // tbFilter
            // 
            tbFilter.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            tbFilter.Location = new System.Drawing.Point(12, 1079);
            tbFilter.Name = "tbFilter";
            tbFilter.Size = new System.Drawing.Size(412, 35);
            tbFilter.TabIndex = 3;
            // 
            // button1
            // 
            button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            button1.Location = new System.Drawing.Point(430, 1079);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(102, 35);
            button1.TabIndex = 4;
            button1.Text = "Filter...";
            button1.UseVisualStyleBackColor = true;
            button1.Click += OnApplyFilter;
            // 
            // SkillExplorer
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(2247, 1126);
            Controls.Add(button1);
            Controls.Add(tbFilter);
            Controls.Add(tbOutput);
            Controls.Add(label1);
            Controls.Add(lbSkills);
            Name = "SkillExplorer";
            Text = "Skill Explorer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListBox lbSkills;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.Button button1;
    }
}