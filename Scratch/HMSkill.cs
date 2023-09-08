using Raid.Toolkit.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM
{
    internal class HMSkill
    {
        private SkillType skill;
        private HMStaticData staticData;

        public HMSkill(SkillType skill, HMStaticData staticData)
        {
            this.skill = skill;
            this.staticData = staticData;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.staticData.GetLocalizedString(this.skill.Name.Key));
            sb.AppendLine(this.staticData.GetLocalizedString(this.skill.Description.Key));
            sb.AppendFormat("Cooldowns: {0}{1}", this.skill.Cooldown, Environment.NewLine);
            if (this.skill.SkillBonuses != null)
            {
                foreach (SkillBonus bonus in this.skill.SkillBonuses)
                {
                    sb.AppendFormat("Skill Bonus: {0} : {1}{2}", bonus.SkillBonusType, bonus.Value, Environment.NewLine);
                }
            }
            if (this.skill.Effects != null)
            {
                foreach (EffectType effect in this.skill.Effects)
                {
                    sb.AppendFormat("Effect {0}:{1}", effect.KindId, Environment.NewLine);
                    sb.AppendFormat(" MultiplierFormula: {0}{1}", effect.MultiplierFormula, Environment.NewLine);
                    sb.AppendFormat(" Condition: {0}{1}", effect.Condition, Environment.NewLine);
                }
            }

            return sb.ToString();
        }
    }
}
