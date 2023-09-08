// See https://aka.ms/new-console-template for more information
using Raid.Client;
using Raid.Toolkit.DataModel;
using HM;

Console.WriteLine("Hello, World!");

RaidToolkitClient client = new RaidToolkitClient();
client.Connect();

try
{
    HMStaticData staticData = await HMStaticData.Get(client.StaticDataApi);
    foreach (var skill in staticData.GetSkillTypes())
    {
        if (skill.Effects != null)
        {
            foreach (var effect in skill.Effects)
            {
                if (effect.Relation != null)
                {
                    if (effect.Relation.Phases != null)
                    {
                        foreach (var phase in effect.Relation.Phases)
                        {
                            if (phase == BattlePhaseId.BeforeDestroyHpDealt)
                            {
                                HMSkill hmSkill = new HMSkill(skill, staticData);
                                Console.WriteLine(hmSkill.ToString());

                                foreach (var hero in staticData.GetHeroTypes())
                                {
                                    if (hero.SkillTypeIds != null && hero.Name != null)
                                    {
                                        if (hero.SkillTypeIds.Contains(skill.TypeId))
                                        {
                                            Console.WriteLine("Skill found on {0}", staticData.GetLocalizedString(hero.Name.Key));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
/*
    var hero = staticData.GetHeroType(4266); // Trunda
    HMHero trunda = new HMHero(hero, staticData);
    Console.WriteLine(trunda.ToString());
*/
}
finally
{
    client.Disconnect();
}
