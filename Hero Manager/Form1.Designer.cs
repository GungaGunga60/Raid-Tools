namespace Hero_Manager
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lvHeroes = new System.Windows.Forms.ListView();
            this.chName = new System.Windows.Forms.ColumnHeader();
            this.chStars = new System.Windows.Forms.ColumnHeader();
            this.chLevel = new System.Windows.Forms.ColumnHeader();
            this.chFood = new System.Windows.Forms.ColumnHeader();
            this.chBook = new System.Windows.Forms.ColumnHeader();
            this.chRequiredBooks = new System.Windows.Forms.ColumnHeader();
            this.chInVault = new System.Windows.Forms.ColumnHeader();
            this.chLocked = new System.Windows.Forms.ColumnHeader();
            this.chFactionGuardian = new System.Windows.Forms.ColumnHeader();
            this.chGearCount = new System.Windows.Forms.ColumnHeader();
            this.cbMultiples = new System.Windows.Forms.CheckBox();
            this.cbEpicsOrBetter = new System.Windows.Forms.CheckBox();
            this.cbIgnoreFactionGuardians = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reloadToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1503, 38);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.Size = new System.Drawing.Size(94, 34);
            this.reloadToolStripMenuItem.Text = "Reload";
            this.reloadToolStripMenuItem.Click += new System.EventHandler(this.OnReloadHeroes);
            // 
            // lvHeroes
            // 
            this.lvHeroes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvHeroes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chStars,
            this.chLevel,
            this.chFood,
            this.chBook,
            this.chRequiredBooks,
            this.chInVault,
            this.chLocked,
            this.chFactionGuardian,
            this.chGearCount});
            this.lvHeroes.FullRowSelect = true;
            this.lvHeroes.GridLines = true;
            this.lvHeroes.HideSelection = false;
            this.lvHeroes.Location = new System.Drawing.Point(12, 41);
            this.lvHeroes.Name = "lvHeroes";
            this.lvHeroes.Size = new System.Drawing.Size(1201, 1372);
            this.lvHeroes.TabIndex = 1;
            this.lvHeroes.UseCompatibleStateImageBehavior = false;
            this.lvHeroes.View = System.Windows.Forms.View.Details;
            this.lvHeroes.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.OnColumnClicked);
            // 
            // chName
            // 
            this.chName.Text = "Name";
            this.chName.Width = 200;
            // 
            // chStars
            // 
            this.chStars.Text = "Stars";
            // 
            // chLevel
            // 
            this.chLevel.Text = "Level";
            // 
            // chFood
            // 
            this.chFood.Text = "Food?";
            this.chFood.Width = 75;
            // 
            // chBook
            // 
            this.chBook.Text = "Book?";
            this.chBook.Width = 75;
            // 
            // chRequiredBooks
            // 
            this.chRequiredBooks.Text = "Books Required";
            this.chRequiredBooks.Width = 175;
            // 
            // chInVault
            // 
            this.chInVault.Text = "In Vault?";
            this.chInVault.Width = 100;
            // 
            // chLocked
            // 
            this.chLocked.Text = "Locked?";
            this.chLocked.Width = 100;
            // 
            // chFactionGuardian
            // 
            this.chFactionGuardian.Text = "Faction Guardian?";
            this.chFactionGuardian.Width = 200;
            // 
            // chGearCount
            // 
            this.chGearCount.Text = "Gear Count";
            this.chGearCount.Width = 125;
            // 
            // cbMultiples
            // 
            this.cbMultiples.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMultiples.AutoSize = true;
            this.cbMultiples.Location = new System.Drawing.Point(1219, 79);
            this.cbMultiples.Name = "cbMultiples";
            this.cbMultiples.Size = new System.Drawing.Size(200, 34);
            this.cbMultiples.TabIndex = 2;
            this.cbMultiples.Text = "Filter to Multiples";
            this.cbMultiples.UseVisualStyleBackColor = true;
            this.cbMultiples.CheckedChanged += new System.EventHandler(this.OnFilterToMultiplesChanged);
            // 
            // cbEpicsOrBetter
            // 
            this.cbEpicsOrBetter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbEpicsOrBetter.AutoSize = true;
            this.cbEpicsOrBetter.Location = new System.Drawing.Point(1219, 119);
            this.cbEpicsOrBetter.Name = "cbEpicsOrBetter";
            this.cbEpicsOrBetter.Size = new System.Drawing.Size(172, 34);
            this.cbEpicsOrBetter.TabIndex = 3;
            this.cbEpicsOrBetter.Text = "Epics or Better";
            this.cbEpicsOrBetter.UseVisualStyleBackColor = true;
            this.cbEpicsOrBetter.CheckedChanged += new System.EventHandler(this.OnEpicsOrBetterChanged);
            // 
            // cbIgnoreFactionGuardians
            // 
            this.cbIgnoreFactionGuardians.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbIgnoreFactionGuardians.AutoSize = true;
            this.cbIgnoreFactionGuardians.Location = new System.Drawing.Point(1219, 159);
            this.cbIgnoreFactionGuardians.Name = "cbIgnoreFactionGuardians";
            this.cbIgnoreFactionGuardians.Size = new System.Drawing.Size(270, 34);
            this.cbIgnoreFactionGuardians.TabIndex = 4;
            this.cbIgnoreFactionGuardians.Text = "Ignore Faction Guardians";
            this.cbIgnoreFactionGuardians.UseVisualStyleBackColor = true;
            this.cbIgnoreFactionGuardians.CheckedChanged += new System.EventHandler(this.OnIgnoreFactionGuardians);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1503, 1425);
            this.Controls.Add(this.cbIgnoreFactionGuardians);
            this.Controls.Add(this.cbEpicsOrBetter);
            this.Controls.Add(this.cbMultiples);
            this.Controls.Add(this.lvHeroes);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Hero Manager";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
        private System.Windows.Forms.ListView lvHeroes;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chStars;
        private System.Windows.Forms.ColumnHeader chLevel;
        private System.Windows.Forms.ColumnHeader chInVault;
        private System.Windows.Forms.ColumnHeader chLocked;
        private System.Windows.Forms.ColumnHeader chGearCount;
        private System.Windows.Forms.ColumnHeader chRequiredBooks;
        private System.Windows.Forms.ColumnHeader chFood;
        private System.Windows.Forms.ColumnHeader chBook;
        private System.Windows.Forms.CheckBox cbMultiples;
        private System.Windows.Forms.CheckBox cbEpicsOrBetter;
        private System.Windows.Forms.ColumnHeader chFactionGuardian;
        private System.Windows.Forms.CheckBox cbIgnoreFactionGuardians;
    }
}
