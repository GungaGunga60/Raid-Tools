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
            this.chInVault = new System.Windows.Forms.ColumnHeader();
            this.chLocked = new System.Windows.Forms.ColumnHeader();
            this.chGearCount = new System.Windows.Forms.ColumnHeader();
            this.chRequiredBooks = new System.Windows.Forms.ColumnHeader();
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
            this.menuStrip1.Size = new System.Drawing.Size(1800, 38);
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
            this.chRequiredBooks,
            this.chInVault,
            this.chLocked,
            this.chGearCount});
            this.lvHeroes.HideSelection = false;
            this.lvHeroes.Location = new System.Drawing.Point(12, 41);
            this.lvHeroes.Name = "lvHeroes";
            this.lvHeroes.Size = new System.Drawing.Size(1776, 1372);
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
            // chGearCount
            // 
            this.chGearCount.Text = "Gear Count";
            this.chGearCount.Width = 125;
            // 
            // chRequiredBooks
            // 
            this.chRequiredBooks.Text = "Books Required";
            this.chRequiredBooks.Width = 175;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1800, 1425);
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
    }
}
