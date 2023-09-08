using Hero_Manager.Data_Model;
using Raid.Toolkit.DataModel;
using RaidExtractor.Core;
using System;
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
    internal partial class SkillExplorer : Form
    {
        HMStaticData staticData;

        public SkillExplorer(HMStaticData staticData)
        {
            InitializeComponent();
            this.staticData = staticData;
            this.LoadSkills();
        }

        private class SkillWrapper
        {
            public HMSkill Skill { get; private set; }
            public HMHero Hero { get; private set; }

            internal SkillWrapper(HMHero hero, HMSkill skill)
            {
                this.Hero = hero;
                this.Skill = skill;
            }

            public override string ToString()
            {
                return this.Skill.Name + " (" + this.Hero.Name + ")";
            }
        }

        private static bool FilterMatchesHero(string filter, HMHero hero)
        {
            return hero.Name.ToLowerInvariant().Contains(filter);
        }

        private static bool FilterMatchesSkill(string filter, HMSkill skill)
        {
            if (skill.Name.ToLowerInvariant().Contains(filter))
            {
                return true;
            }

            foreach (EffectType effect in skill.Effects)
            {
                if (effect.Condition != null && effect.Condition.ToLowerInvariant().Contains(filter))
                {
                    return true;
                }

                if (effect.MultiplierFormula != null && effect.MultiplierFormula.ToLowerInvariant().Contains(filter))
                {
                    return true;
                }
            }

            return false;
        }

        private void LoadSkills()
        {
            this.lbSkills.Items.Clear();

            string filter = this.tbFilter.Text.ToLowerInvariant();
            foreach (HeroType hero in staticData.GetHeroTypes())
            {
                bool includeAllSkills = string.IsNullOrEmpty(filter);
                if (hero.Ascended == 6 && hero.SkillTypeIds != null)
                {
                    HMHero hmHero = new HMHero(hero, staticData);
                    if (includeAllSkills || FilterMatchesHero(filter, hmHero))
                    {
                        includeAllSkills = true;
                    }

                    foreach (HMSkill hmSkill in hmHero.Skills)
                    {
                        if (includeAllSkills || FilterMatchesSkill(filter, hmSkill))
                        {
                            this.lbSkills.Items.Add(new SkillWrapper(hmHero, hmSkill));
                        }
                    }
                }
            }

            this.tbOutput.Text = string.Empty;
        }

        private void lbSkills_SelectedIndexChanged(object sender, EventArgs e)
        {
            SkillWrapper wrapper = (SkillWrapper)this.lbSkills.SelectedItem;
            if (wrapper != null)
            {
                this.tbOutput.Text = wrapper.Skill.ToString();
            }
        }

        private void OnApplyFilter(object sender, EventArgs e)
        {
            this.LoadSkills();
        }
    }
}
