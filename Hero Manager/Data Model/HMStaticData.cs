using Newtonsoft.Json;
using Raid.Toolkit.DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hero_Manager.Data_Model
{
    internal class HMStaticData
    {
        public StaticArenaData ArenaData { get; private set; }
        public StaticArtifactData ArtifactData { get; private set; }
        public StaticHeroTypeData HeroData { get; private set; }
        public IReadOnlyDictionary<string, string> LocalizedStrings { get; private set; }
        public StaticSkillData SkillData { get; private set; }
        public StaticStageData StageData { get; private set; }

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

        public static async Task<HMStaticData> LoadFromStream(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                string json = await reader.ReadToEndAsync();
                StaticGameData? data = JsonConvert.DeserializeObject<StaticGameData>(json);
                if (data != null)
                {
                    return new HMStaticData(data.ArenaData, data.ArtifactData, data.HeroData, data.LocalizedStrings, data.SkillData, data.StageData);
                }
            }

            return null;
        }

        private HMStaticData(StaticArenaData arenaData, StaticArtifactData artifactData, StaticHeroTypeData heroTypeData, IReadOnlyDictionary<string, string> localizedStrings, StaticSkillData skillData, StaticStageData stageData)
        {
            this.ArenaData = arenaData;
            this.ArtifactData = artifactData;
            this.HeroData = heroTypeData;
            this.LocalizedStrings = localizedStrings;
            this.SkillData = skillData;
            this.StageData = stageData;
        }

        public IEnumerable<HeroType> GetHeroTypes()
        {
            foreach (var hero in this.HeroData.HeroTypes.Values)
            {
                yield return hero;
            }
        }

        public HeroType GetHeroType(int typeId)
        {
            HeroType val;
            if (this.HeroData.HeroTypes.TryGetValue(typeId, out val))
            {
                return val;
            }

            return null;
        }

        public string GetLocalizedString(string key)
        {
            string val;
            if (this.LocalizedStrings.TryGetValue(key, out val))
            {
                return val;
            }

            return string.Empty;
        }

        public IEnumerable<SkillType> GetSkillTypes()
        {
            foreach (var skill in this.SkillData.SkillTypes.Values)
            {
                yield return skill;
            }
        }

        public SkillType GetSkillType(int skillTypeId)
        {
            SkillType result;
            if (!this.SkillData.SkillTypes.TryGetValue(skillTypeId, out result))
            {
                return null;
            }

            return result;
        }

        private class StaticGameData
        {
            [JsonProperty("arena")]
            public StaticArenaData ArenaData;

            [JsonProperty("artifact")]
            public StaticArtifactData ArtifactData;

            [JsonProperty("hero")]
            public StaticHeroTypeData HeroData;

            [JsonProperty("strings")]
            public IReadOnlyDictionary<string, string> LocalizedStrings;

            [JsonProperty("skills")]
            public StaticSkillData SkillData;

            [JsonProperty("stages")]
            public StaticStageData StageData;
        }
        public void SerializeToStream(StreamWriter writer)
        {
            StaticGameData game = new StaticGameData()
            {
                ArenaData = this.ArenaData,
                ArtifactData = this.ArtifactData,
                HeroData = this.HeroData,
                LocalizedStrings = this.LocalizedStrings,
                SkillData = this.SkillData,
                StageData = this.StageData,
            };

            string json = Serialize.JsonPrettify(JsonConvert.SerializeObject(game));
            writer.Write(json);
        }
    }
}
