using Raid.Client;
using Raid.DataModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hero_Manager
{
    public partial class Form1 : Form
    {
        private RaidToolkitClient api;

        public Form1()
        {
            InitializeComponent();
            this.api = new RaidToolkitClient();
            this.api.Connect();
        }

        private async void OnReloadHeroes(object sender, EventArgs e)
        {
            this.lvHeroes.Items.Clear();
            var accounts = await api.AccountApi.GetAccounts();
            var skillData = await api.StaticDataApi.GetSkillData();
            var accountId = accounts.First().Id;
            this.Text = string.Format("{0}'s Heroes", accounts.First().Name);
            foreach (var hero in await api.AccountApi.GetHeroes(accountId))
            {
                // name, stars, level, books required, in vault?, locked?, gear count
                ListViewItem item = new ListViewItem(hero.Name);
                item.SubItems.Add(hero.Rank.Substring(5));
                item.SubItems.Add(hero.Level.ToString());
                item.SubItems.Add(CountBooksRequired(hero, skillData).ToString());
                item.SubItems.Add(hero.InVault ? "X" : string.Empty);
                item.SubItems.Add(hero.Locked ? "X" : String.Empty);
                item.SubItems.Add(hero.EquippedArtifactIds.Count.ToString());
                this.lvHeroes.Items.Add(item);
            }
        }

        private static int CountBooksRequired(Hero hero, StaticSkillData skillData)
        {
            int booksRequired = 0;
            foreach (var skill in hero.SkillsById.Values)
            {
                int booksNeededForSkill = skillData.SkillTypes[skill.TypeId].Upgrades.Count();
                int booksAppliedToSkill = skill.Level - 1;
                booksRequired += (booksNeededForSkill - booksAppliedToSkill);
            }

            return booksRequired;
        }

        private void OnColumnClicked(object sender, ColumnClickEventArgs e)
        {
            this.lvHeroes.ListViewItemSorter = HeroSorter.Get(e.Column, this.lvHeroes.ListViewItemSorter as HeroSorter);
        }

        #region Sorter
        private class HeroSorter : IComparer
        {
            private int col;
            private bool ascending;

            private HeroSorter(int col, bool ascending)
            {
                this.col = col;
                this.ascending = ascending;
            }

            public static HeroSorter Get(int col, HeroSorter prev)
            {
                if (prev != null && prev.col == col)
                {
                    return new HeroSorter(col, !prev.ascending);
                }

                return new HeroSorter(col, true);
            }

            public int Compare(object? x, object? y)
            {
                ListViewItem? a = x as ListViewItem;
                ListViewItem? b = y as ListViewItem;

                string aText = a != null ? a.SubItems[this.col].Text : String.Empty;
                string bText = b != null ? b.SubItems[this.col].Text : String.Empty;

                if (this.ascending)
                {
                    return aText.CompareTo(bText);
                }
                else
                {
                    return bText.CompareTo(aText);
                }
            }
        }
        #endregion
    }
}
