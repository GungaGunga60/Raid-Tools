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
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            heroesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            factionGuardianFinderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            skillExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            staticDataToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            exportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            lvHeroes = new System.Windows.Forms.ListView();
            chName = new System.Windows.Forms.ColumnHeader();
            chStars = new System.Windows.Forms.ColumnHeader();
            chLevel = new System.Windows.Forms.ColumnHeader();
            chFood = new System.Windows.Forms.ColumnHeader();
            chBook = new System.Windows.Forms.ColumnHeader();
            chRequiredBooks = new System.Windows.Forms.ColumnHeader();
            chInMasterVault = new System.Windows.Forms.ColumnHeader();
            chInReserveVault = new System.Windows.Forms.ColumnHeader();
            chLocked = new System.Windows.Forms.ColumnHeader();
            chFaction = new System.Windows.Forms.ColumnHeader();
            chFactionGuardian = new System.Windows.Forms.ColumnHeader();
            chGearCount = new System.Windows.Forms.ColumnHeader();
            cbMultiples = new System.Windows.Forms.CheckBox();
            cbEpicsOrBetter = new System.Windows.Forms.CheckBox();
            cbIgnoreFactionGuardians = new System.Windows.Forms.CheckBox();
            cbIgnoreFoodAndBooks = new System.Windows.Forms.CheckBox();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { reloadToolStripMenuItem, exportToolStripMenuItem, toolsToolStripMenuItem, staticDataToolStripMenuItem1 });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(1934, 38);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // reloadToolStripMenuItem
            // 
            reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            reloadToolStripMenuItem.Size = new System.Drawing.Size(94, 34);
            reloadToolStripMenuItem.Text = "Reload";
            reloadToolStripMenuItem.Click += OnReloadHeroes;
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { heroesToolStripMenuItem });
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new System.Drawing.Size(90, 34);
            exportToolStripMenuItem.Text = "Export";
            // 
            // heroesToolStripMenuItem
            // 
            heroesToolStripMenuItem.Name = "heroesToolStripMenuItem";
            heroesToolStripMenuItem.Size = new System.Drawing.Size(315, 40);
            heroesToolStripMenuItem.Text = "Heroes...";
            heroesToolStripMenuItem.Click += OnExportAsCsv;
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { factionGuardianFinderToolStripMenuItem, skillExplorerToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new System.Drawing.Size(78, 34);
            toolsToolStripMenuItem.Text = "Tools";
            // 
            // factionGuardianFinderToolStripMenuItem
            // 
            factionGuardianFinderToolStripMenuItem.Name = "factionGuardianFinderToolStripMenuItem";
            factionGuardianFinderToolStripMenuItem.Size = new System.Drawing.Size(350, 40);
            factionGuardianFinderToolStripMenuItem.Text = "Faction Guardian Finder";
            factionGuardianFinderToolStripMenuItem.Click += OnLaunchFactionGuardianFinder;
            // 
            // skillExplorerToolStripMenuItem
            // 
            skillExplorerToolStripMenuItem.Name = "skillExplorerToolStripMenuItem";
            skillExplorerToolStripMenuItem.Size = new System.Drawing.Size(350, 40);
            skillExplorerToolStripMenuItem.Text = "Skill Explorer";
            skillExplorerToolStripMenuItem.Click += OnLaunchSkillExplorer;
            // 
            // staticDataToolStripMenuItem1
            // 
            staticDataToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { exportToolStripMenuItem1, importToolStripMenuItem });
            staticDataToolStripMenuItem1.Name = "staticDataToolStripMenuItem1";
            staticDataToolStripMenuItem1.Size = new System.Drawing.Size(131, 34);
            staticDataToolStripMenuItem1.Text = "Static Data";
            // 
            // exportToolStripMenuItem1
            // 
            exportToolStripMenuItem1.Name = "exportToolStripMenuItem1";
            exportToolStripMenuItem1.Size = new System.Drawing.Size(315, 40);
            exportToolStripMenuItem1.Text = "Export...";
            exportToolStripMenuItem1.Click += OnExportStaticData;
            // 
            // importToolStripMenuItem
            // 
            importToolStripMenuItem.Name = "importToolStripMenuItem";
            importToolStripMenuItem.Size = new System.Drawing.Size(315, 40);
            importToolStripMenuItem.Text = "Import...";
            importToolStripMenuItem.Click += OnImportStaticData;
            // 
            // lvHeroes
            // 
            lvHeroes.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lvHeroes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { chName, chStars, chLevel, chFood, chBook, chRequiredBooks, chInMasterVault, chInReserveVault, chLocked, chFaction, chFactionGuardian, chGearCount });
            lvHeroes.FullRowSelect = true;
            lvHeroes.GridLines = true;
            lvHeroes.Location = new System.Drawing.Point(12, 41);
            lvHeroes.Name = "lvHeroes";
            lvHeroes.Size = new System.Drawing.Size(1632, 1372);
            lvHeroes.TabIndex = 1;
            lvHeroes.UseCompatibleStateImageBehavior = false;
            lvHeroes.View = System.Windows.Forms.View.Details;
            lvHeroes.ColumnClick += OnColumnClicked;
            // 
            // chName
            // 
            chName.Text = "Name";
            chName.Width = 200;
            // 
            // chStars
            // 
            chStars.Text = "Stars";
            // 
            // chLevel
            // 
            chLevel.Text = "Level";
            // 
            // chFood
            // 
            chFood.Text = "Food?";
            chFood.Width = 75;
            // 
            // chBook
            // 
            chBook.Text = "Book?";
            chBook.Width = 75;
            // 
            // chRequiredBooks
            // 
            chRequiredBooks.Text = "Books Required";
            chRequiredBooks.Width = 175;
            // 
            // chInMasterVault
            // 
            chInMasterVault.Text = "In Master Vault?";
            chInMasterVault.Width = 180;
            // 
            // chInReserveVault
            // 
            chInReserveVault.Text = "In Reserve Vault?";
            chInReserveVault.Width = 180;
            // 
            // chLocked
            // 
            chLocked.Text = "Locked?";
            chLocked.Width = 100;
            // 
            // chFaction
            // 
            chFaction.Text = "Faction";
            chFaction.Width = 150;
            // 
            // chFactionGuardian
            // 
            chFactionGuardian.Text = "Faction Guardian?";
            chFactionGuardian.Width = 200;
            // 
            // chGearCount
            // 
            chGearCount.Text = "Gear Count";
            chGearCount.Width = 125;
            // 
            // cbMultiples
            // 
            cbMultiples.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cbMultiples.AutoSize = true;
            cbMultiples.Location = new System.Drawing.Point(1650, 79);
            cbMultiples.Name = "cbMultiples";
            cbMultiples.Size = new System.Drawing.Size(200, 34);
            cbMultiples.TabIndex = 2;
            cbMultiples.Text = "Filter to Multiples";
            cbMultiples.UseVisualStyleBackColor = true;
            // 
            // cbEpicsOrBetter
            // 
            cbEpicsOrBetter.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cbEpicsOrBetter.AutoSize = true;
            cbEpicsOrBetter.Location = new System.Drawing.Point(1650, 119);
            cbEpicsOrBetter.Name = "cbEpicsOrBetter";
            cbEpicsOrBetter.Size = new System.Drawing.Size(172, 34);
            cbEpicsOrBetter.TabIndex = 3;
            cbEpicsOrBetter.Text = "Epics or Better";
            cbEpicsOrBetter.UseVisualStyleBackColor = true;
            // 
            // cbIgnoreFactionGuardians
            // 
            cbIgnoreFactionGuardians.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cbIgnoreFactionGuardians.AutoSize = true;
            cbIgnoreFactionGuardians.Location = new System.Drawing.Point(1650, 159);
            cbIgnoreFactionGuardians.Name = "cbIgnoreFactionGuardians";
            cbIgnoreFactionGuardians.Size = new System.Drawing.Size(270, 34);
            cbIgnoreFactionGuardians.TabIndex = 4;
            cbIgnoreFactionGuardians.Text = "Ignore Faction Guardians";
            cbIgnoreFactionGuardians.UseVisualStyleBackColor = true;
            // 
            // cbIgnoreFoodAndBooks
            // 
            cbIgnoreFoodAndBooks.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cbIgnoreFoodAndBooks.AutoSize = true;
            cbIgnoreFoodAndBooks.Location = new System.Drawing.Point(1650, 199);
            cbIgnoreFoodAndBooks.Name = "cbIgnoreFoodAndBooks";
            cbIgnoreFoodAndBooks.Size = new System.Drawing.Size(253, 34);
            cbIgnoreFoodAndBooks.TabIndex = 5;
            cbIgnoreFoodAndBooks.Text = "Ignore Food and Books";
            cbIgnoreFoodAndBooks.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1934, 1425);
            Controls.Add(cbIgnoreFoodAndBooks);
            Controls.Add(cbIgnoreFactionGuardians);
            Controls.Add(cbEpicsOrBetter);
            Controls.Add(cbMultiples);
            Controls.Add(lvHeroes);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Hero Manager";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
        private System.Windows.Forms.ListView lvHeroes;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chStars;
        private System.Windows.Forms.ColumnHeader chLevel;
        private System.Windows.Forms.ColumnHeader chInMasterVault;
        private System.Windows.Forms.ColumnHeader chLocked;
        private System.Windows.Forms.ColumnHeader chGearCount;
        private System.Windows.Forms.ColumnHeader chRequiredBooks;
        private System.Windows.Forms.ColumnHeader chFood;
        private System.Windows.Forms.ColumnHeader chBook;
        private System.Windows.Forms.CheckBox cbMultiples;
        private System.Windows.Forms.CheckBox cbEpicsOrBetter;
        private System.Windows.Forms.ColumnHeader chFactionGuardian;
        private System.Windows.Forms.CheckBox cbIgnoreFactionGuardians;
        private System.Windows.Forms.ColumnHeader chFaction;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem factionGuardianFinderToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader chInReserveVault;
        private System.Windows.Forms.CheckBox cbIgnoreFoodAndBooks;
        private System.Windows.Forms.ToolStripMenuItem skillExplorerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem heroesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem staticDataToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
    }
}
