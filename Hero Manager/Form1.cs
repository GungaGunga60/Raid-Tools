using Hero_Manager.Data_Model;
using Newtonsoft.Json;
using Raid.Client;
using Raid.Toolkit.DataModel;
using Raid.Toolkit.DataModel.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hero_Manager
{
    public partial class Form1 : Form
    {
        private RaidToolkitClient api;
        private Data_Model.HMStaticData staticData;
        private StaticSkillData skillData;
        private StaticHeroTypeData heroData;
        private StaticArtifactData artifactData;
        private StaticArenaData arenaData;
        private StaticStageData stageData;
        private IReadOnlyDictionary<string, string> localizedStrings;

        public Form1()
        {
            InitializeComponent();
            this.api = new RaidToolkitClient();
            this.api.Connect();
        }

        private async Task EnsureStaticData()
        {
            if (this.staticData == null)
            {
                this.staticData = await Data_Model.HMStaticData.Get(this.api.StaticDataApi);
            }

            if (this.arenaData == null)
            {
                this.arenaData = await this.api.StaticDataApi.GetArenaData();
            }

            if (this.artifactData == null)
            {
                this.artifactData = await this.api.StaticDataApi.GetArtifactData();
            }

            if (this.heroData == null)
            {
                this.heroData = await this.api.StaticDataApi.GetHeroData();
            }

            if (this.localizedStrings == null)
            {
                this.localizedStrings = await this.api.StaticDataApi.GetLocalizedStrings();
            }

            if (this.stageData == null)
            {
                this.stageData = await this.api.StaticDataApi.GetStageData();
            }

            if (this.skillData == null)
            {
                this.skillData = await this.api.StaticDataApi.GetSkillData();
            }

            /*
            OutputForm of = new OutputForm("All Heroes");
            List<string> heroNames = new List<string>();
            foreach (var hero in this.heroData.HeroTypes.Values)
            {
                heroNames.Add(hero.Name.DefaultValue);
            }
            heroNames.Sort();
            foreach (string heroName in heroNames)
            {
                of.AddLine(heroName);
            }
            of.Show();

            OutputForm of2 = new OutputForm("All Skills");
            List<string> skillNames = new List<string>();
            foreach (var skill in this.skillData.SkillTypes.Values)
            {
                skillNames.Add(skill.Name.DefaultValue);
            }
            skillNames.Sort();
            foreach (string skillName in skillNames)
            {
                of2.AddLine(skillName);
            }
            of2.Show();

            OutputForm of = new OutputForm("Unknown Faction Heroes");
            foreach (var demonLord in this.heroData.HeroTypes.Values.Where(h => h.Faction == HeroFraction.Unknown))
            {
                of.AddLine("Name: " + demonLord.Name.DefaultValue);
                of.AddLine("Affinity: " + demonLord.Affinity);
                of.AddLine("Ascended: " + demonLord.Ascended);
                of.AddLine("Avatar Key: " + demonLord.AvatarKey);
                of.AddLine("Brain: " + demonLord.Brain);
                of.AddLine("Faction: " + demonLord.Faction);
                of.AddLine("Leader Skill: " + demonLord.LeaderSkill);
                of.AddLine("Rarity: " + demonLord.Rarity);
                of.AddLine("Role: " + demonLord.Role);
                of.AddLine("Skill Type Ids: " + String.Join(',', demonLord.SkillTypeIds));
                of.AddLine("Type Id: " + demonLord.TypeId);
                of.AddLine("Unscaled Stats: " + demonLord.UnscaledStats);
                of.AddLine(String.Empty);
            }
            of.Show();
            */
        }

        private async void OnReloadHeroes(object sender, EventArgs e)
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
            var academy = await api.AccountApi.GetAcademy(accountId);
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
                Dictionary<string, List<Hero>> heroesByName = BucketByName(heroes);

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
                    var rarity = heroData.HeroTypes[hero.TypeId].Rarity;
                    if (rarity != HeroRarity.Epic && rarity != HeroRarity.Legendary)
                    {
                        heroes.RemoveAt(i);
                    }
                }
            }

            if (this.cbIgnoreFoodAndBooks.Checked)
            {
                for (int i = heroes.Count - 1; i >= 0; i--)
                {
                    var hero = heroes[i];
                    if (HeroIsFood(hero) || HeroIsBook(hero))
                    {
                        heroes.RemoveAt(i);
                    }
                }
            }

            if (this.cbIgnoreFactionGuardians.Checked)
            {
                Dictionary<string, List<Hero>> factionGuardians = new Dictionary<string, List<Hero>>();
                for (int i = heroes.Count - 1; i >= 0; i--)
                {
                    var hero = heroes[i];
                    if (IsFactionGuardian(hero, academy))
                    {
                        heroes.RemoveAt(i);
                        List<Hero> fgs;
                        if (!factionGuardians.TryGetValue(hero.Name.ToLowerInvariant(), out fgs))
                        {
                            fgs = new List<Hero>();
                            factionGuardians[hero.Name.ToLowerInvariant()] = fgs;
                        }
                        fgs.Add(hero);
                    }
                }

                // Add back the ones where they're not *ALL* faction guardians.
                Dictionary<string, List<Hero>> heroesByName = BucketByName(heroes);
                foreach (string name in heroesByName.Keys)
                {
                    List<Hero> fgs;
                    if (factionGuardians.TryGetValue(name, out fgs))
                    {
                        heroes.AddRange(fgs);
                    }
                }
            }

            if (this.cbMultiples.Checked)
            {
                Dictionary<string, List<Hero>> heroesByName = BucketByName(heroes);

                heroes.Clear();
                foreach (List<Hero> hs in heroesByName.Values)
                {
                    if (hs.Count > 1)
                    {
                        heroes.AddRange(hs);
                    }
                }
            }

            foreach (var hero in heroes)
            {
                // name, stars, level, food?, book?, books required, in master vault?, in reserve vault?, locked?, faction, faction guardian?, gear count
                ListViewItem item = new ListViewItem(hero.Name);
                item.SubItems.Add(hero.Rank.Substring(5));
                item.SubItems.Add(hero.Level.ToString());
                item.SubItems.Add(HeroIsFood(hero) ? "X" : String.Empty);
                item.SubItems.Add(HeroIsBook(hero) ? "X" : String.Empty);
                item.SubItems.Add(CountBooksRequired(hero, this.skillData).ToString());
                item.SubItems.Add(hero.InVault ? "X" : String.Empty);
                item.SubItems.Add(hero.InDeepVault ? "X" : String.Empty);
                item.SubItems.Add(hero.Locked ? "X" : String.Empty);
                item.SubItems.Add(hero.Type.Faction.ToString());
                item.SubItems.Add(IsFactionGuardian(hero, academy) ? "X" : String.Empty);
                item.SubItems.Add(hero.EquippedArtifactIds.Count.ToString());

                this.lvHeroes.Items.Add(item);
            }
            this.Text = string.Format("{0}'s Heroes", accounts.First().Name);
        }

        private static bool HeroIsFood(Hero hero)
        {
            return hero.Marker == "Speed";
        }

        private static bool HeroIsBook(Hero hero)
        {
            return hero.Marker == "Support";
        }

        private static Dictionary<string, List<Hero>> BucketByName(IEnumerable<Hero> heroes)
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

            return heroesByName;
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

        private static bool IsFactionGuardian(Hero hero, AcademyData academy)
        {
            Dictionary<HeroRarity, GuardianData> factionData = null;
            if (academy.Guardians.TryGetValue(hero.Type.Faction.Value, out factionData))
            {
                GuardianData guardianData = null;
                if (factionData.TryGetValue(hero.Type.Rarity.Value, out guardianData))
                {
                    foreach (var guardianSlot in guardianData.AssignedHeroes)
                    {
                        if (hero.Id == guardianSlot.FirstHero || hero.Id == guardianSlot.SecondHero)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private void OnColumnClicked(object sender, ColumnClickEventArgs e)
        {
            this.lvHeroes.ListViewItemSorter = HeroSorter.Get(e.Column, this.lvHeroes.ListViewItemSorter as HeroSorter);
        }

        private void OnExportAsCsv(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "csv files (*.csv)|*.csv";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                List<string> values = new List<string>();
                using (StreamWriter file = new StreamWriter(sfd.OpenFile()))
                {
                    values.Clear();
                    foreach (var col in this.lvHeroes.Columns)
                    {
                        values.Add(((ColumnHeader)col).Text);
                    }
                    file.WriteLine(string.Join(',', values));

                    foreach (var item in this.lvHeroes.Items)
                    {
                        values.Clear();
                        foreach (var subitem in ((ListViewItem)item).SubItems)
                        {
                            values.Add(((ListViewItem.ListViewSubItem)subitem).Text);
                        }
                        file.WriteLine(string.Join(',', values));
                    }

                    file.Flush();
                }
            }
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

        private async void OnLaunchFactionGuardianFinder(object sender, EventArgs e)
        {
            var accounts = await api.AccountApi.GetAccounts();
            var accountId = accounts.First().Id;
            var academy = await api.AccountApi.GetAcademy(accountId);
            List<Hero> heroes = new List<Hero>(await api.AccountApi.GetHeroes(accountId));

            new FactionGuardianFinder(heroes, academy).Show();
        }

        private async void OnLaunchSkillExplorer(object sender, EventArgs e)
        {
            await this.EnsureStaticData();
            new SkillExplorer(this.staticData).Show();
        }

        private async void OnExportStaticData(object sender, EventArgs e)
        {
            await this.EnsureStaticData();
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "json files (*.json)|*.json";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter file = new StreamWriter(sfd.OpenFile()))
                {
                    this.staticData.SerializeToStream(file);
                    file.Flush();
                }
            }
        }
    }
}
