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
        private StaticSkillData skillData;
        private StaticHeroData heroData;

        public Form1()
        {
            InitializeComponent();
            this.api = new RaidToolkitClient();
            this.api.Connect();
        }

        private async Task EnsureStaticData()
        {
            if (this.skillData == null)
            {
                this.skillData = await this.api.StaticDataApi.GetSkillData();
            }

            if (this.heroData == null)
            { 
                this.heroData = await this.api.StaticDataApi.GetHeroData();
            }
        }

        private async void OnReloadHeroes(object sender, EventArgs e)
        {
            await ReloadHeroes();
        }

        private async void OnFilterToMultiplesChanged(object sender, EventArgs e)
        {
            await ReloadHeroes();
        }

        private async void OnEpicsOrBetterChanged(object sender, EventArgs e)
        {
            await ReloadHeroes();
        }

        private async Task ReloadHeroes()
        {
            this.lvHeroes.Items.Clear();
            var accounts = await api.AccountApi.GetAccounts();
            var accountId = accounts.First().Id;
            this.Text = string.Format("{0}'s Heroes (Loading...)", accounts.First().Name);
            await this.EnsureStaticData();
            List<Hero> heroes = new List<Hero>(await api.AccountApi.GetHeroes(accountId));
            
            for (int i = heroes.Count - 1; i >= 0; i--)
            {
                if (heroes[i].Deleted)
                {
                    heroes.RemoveAt(i);
                }
            }

            if (this.cbMultiples.Checked)
            {
                Dictionary<string, List<Hero>> heroesByName = new Dictionary<string, List<Hero>>();
                foreach (var hero in heroes)
                {
                    List<Hero> hs = null;
                    if (!heroesByName.TryGetValue(hero.Name.ToLowerInvariant(), out hs))
                    {
                        hs = new List<Hero>();
                        heroesByName[hero.Name.ToLowerInvariant()] = hs;
                    }
                    hs.Add(hero);
                }

                heroes.Clear();
                foreach (List<Hero> hs in heroesByName.Values)
                {
                    if (hs.Count > 1)
                    {
                        heroes.AddRange(hs);
                    }
                }
            }

            if (this.cbEpicsOrBetter.Checked)
            {
                for (int i = heroes.Count - 1; i >= 0; i--)
                {
                    var hero = heroes[i];
                    string rarity = heroData.HeroTypes[hero.TypeId].Rarity;
                    if (rarity != "Epic" && rarity != "Legendary")
                    {
                        heroes.RemoveAt(i);
                    }
                }
            }

            foreach (var hero in heroes)
            {
                // name, stars, level, food?, book?, books required, in vault?, locked?, gear count
                ListViewItem item = new ListViewItem(hero.Name);
                item.SubItems.Add(hero.Rank.Substring(5));
                item.SubItems.Add(hero.Level.ToString());
                item.SubItems.Add(hero.Marker == "Speed" ? "X" : String.Empty);
                item.SubItems.Add(hero.Marker == "Support" ? "X" : String.Empty);
                item.SubItems.Add(CountBooksRequired(hero, this.skillData).ToString());
                item.SubItems.Add(hero.InVault ? "X" : String.Empty);
                item.SubItems.Add(hero.Locked ? "X" : String.Empty);
                item.SubItems.Add(hero.EquippedArtifactIds.Count.ToString());
                
                this.lvHeroes.Items.Add(item);
            }
            this.Text = string.Format("{0}'s Heroes", accounts.First().Name);
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
