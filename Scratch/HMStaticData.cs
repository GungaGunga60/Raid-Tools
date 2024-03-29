﻿using Raid.Toolkit.DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM
{
    internal class HMStaticData
    {
        private StaticArenaData arenaData;
        private StaticArtifactData artifactData;
        private StaticHeroTypeData heroData;
        private IReadOnlyDictionary<string, string> localizedStrings;
        private StaticSkillData skillData;
        private StaticStageData stageData;

        public static async Task<HMStaticData> Get(IStaticDataApi staticDataApi)
        {
            StaticArenaData arenaData = await staticDataApi.GetArenaData();
            StaticArtifactData artifactData = await staticDataApi.GetArtifactData();
            StaticHeroTypeData heroData = await staticDataApi.GetHeroData();
            IReadOnlyDictionary<string, string> localizedStrings = await staticDataApi.GetLocalizedStrings();
            StaticSkillData skillData = await staticDataApi.GetSkillData();
            StaticStageData stageData = await staticDataApi.GetStageData();

            return new HMStaticData(arenaData, artifactData, heroData, localizedStrings, skillData, stageData);
        }

        private HMStaticData(StaticArenaData arenaData, StaticArtifactData artifactData, StaticHeroTypeData heroTypeData, IReadOnlyDictionary<string, string> localizedStrings, StaticSkillData skillData, StaticStageData stageData)
        {
            this.arenaData = arenaData;
            this.artifactData = artifactData;
            this.heroData = heroTypeData;
            this.localizedStrings = localizedStrings;
            this.skillData = skillData;
            this.stageData = stageData;
        }

        public IEnumerable<HeroType> GetHeroTypes()
        {
            foreach (var hero in this.heroData.HeroTypes.Values)
            {
                yield return hero;
            }
        }

        public HeroType GetHeroType(int typeId)
        {
            HeroType val;
            if (this.heroData.HeroTypes.TryGetValue(typeId, out val))
            {
                return val;
            }

            return null;
        }

        public string GetLocalizedString(string key)
        {
            string val;
            if (this.localizedStrings.TryGetValue(key, out val))
            {
                return val;
            }

            return string.Empty;
        }

        public IEnumerable<SkillType> GetSkillTypes()
        {
            foreach (var skill in this.skillData.SkillTypes.Values)
            {
                yield return skill;
            }
        }

        public SkillType GetSkillType(int skillTypeId)
        {
            SkillType result;
            if (!this.skillData.SkillTypes.TryGetValue(skillTypeId, out result))
            {
                return null;
            }

            return result;
        }
    }
}
