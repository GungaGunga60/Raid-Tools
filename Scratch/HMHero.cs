using Raid.Toolkit.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HM
{
    internal class HMHero
    {
        private HeroType hero;
        private HMStaticData staticData;
        private List<HMSkill> skills;

        public HMHero(HeroType hero, HMStaticData staticData)
        {
            this.hero = hero;
            this.staticData = staticData;
            this.skills = new List<HMSkill>();
            if (this.hero.SkillTypeIds != null)
            {
                foreach (int skillTypeId in this.hero.SkillTypeIds)
                {
                    SkillType skill = this.staticData.GetSkillType(skillTypeId);
                    this.skills.Add(new HMSkill(skill, staticData));
                }
            }
        }

        public IReadOnlyList<HMSkill> Skills { get { return this.skills; } }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            // Name
            sb.AppendFormat("Name: {0}{1}", this.staticData.GetLocalizedString(hero.Name.Key), Environment.NewLine);
            sb.AppendFormat("Short Name: {0}{1}", this.staticData.GetLocalizedString(hero.ShortName.Key), Environment.NewLine);

            // Skills
            sb.AppendLine("Skills:");
            foreach (HMSkill skill in this.Skills)
            {
                sb.AppendLine(skill.ToString());
            }

            // Stats
            if (this.hero.UnscaledStats != null)
            {
                sb.AppendLine("Stats:");
                sb.AppendFormat("  HP:      {0}{1}", this.hero.UnscaledStats.Health, Environment.NewLine);
                sb.AppendFormat("  ATK:     {0}{1}", this.hero.UnscaledStats.Attack, Environment.NewLine);
                sb.AppendFormat("  DEF:     {0}{1}", this.hero.UnscaledStats.Defense, Environment.NewLine);
                sb.AppendFormat("  SPD:     {0}{1}", this.hero.UnscaledStats.Speed, Environment.NewLine);
                sb.AppendFormat("  C. RATE: {0}{1}", this.hero.UnscaledStats.CriticalChance, Environment.NewLine);
                sb.AppendFormat("  C. DMG:  {0}{1}", this.hero.UnscaledStats.CriticalDamage, Environment.NewLine);
                sb.AppendFormat("  RES:     {0}{1}", this.hero.UnscaledStats.Resistance, Environment.NewLine);
                sb.AppendFormat("  ACC:     {0}{1}", this.hero.UnscaledStats.Accuracy, Environment.NewLine);
                sb.AppendFormat("  C. HEAL: {0}{1}", this.hero.UnscaledStats.CriticalHeal, Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}
