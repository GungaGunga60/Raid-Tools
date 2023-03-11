using Raid.Toolkit.DataModel.Enums;
using Raid.Toolkit.DataModel;
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
    public partial class FactionGuardianFinder : Form
    {
        private IEnumerable<HeroRarity> FactionGuardianRarities()
        {
            yield return HeroRarity.Rare;
            yield return HeroRarity.Epic;
            yield return HeroRarity.Legendary;
        }

        public FactionGuardianFinder(List<Hero> heroes, AcademyData academy)
        {
            InitializeComponent();
            Dictionary<HeroFraction, Dictionary<HeroRarity, Dictionary<int, List<Hero>>>> heroesByFactionAndRarityAndId = new Dictionary<HeroFraction, Dictionary<HeroRarity, Dictionary<int, List<Hero>>>>();
            foreach (Hero hero in heroes)
            {
                Dictionary<HeroRarity, Dictionary<int, List<Hero>>> heroesByRarityAndId;
                if (!heroesByFactionAndRarityAndId.TryGetValue(hero.Type.Faction.Value, out heroesByRarityAndId))
                {
                    heroesByRarityAndId = new Dictionary<HeroRarity, Dictionary<int, List<Hero>>>();
                    heroesByFactionAndRarityAndId[hero.Type.Faction.Value] = heroesByRarityAndId;
                }

                Dictionary<int, List<Hero>> heroesById = null;
                if (!heroesByRarityAndId.TryGetValue(hero.Type.Rarity.Value, out heroesById))
                {
                    heroesById = new Dictionary<int, List<Hero>>();
                    heroesByRarityAndId[hero.Type.Rarity.Value] = heroesById;
                }

                List<Hero> heroForId;
                if (!heroesById.TryGetValue(hero.TypeId, out heroForId))
                {
                    heroForId = new List<Hero>();
                    heroesById[hero.TypeId] = heroForId;
                }

                heroForId.Add(hero);
            }

            foreach (HeroFraction faction in Enum.GetValues(typeof (HeroFraction)))
            {
                foreach (HeroRarity rarity in FactionGuardianRarities())
                {
                    // Find the dupe champs
                    Dictionary<int, List<Hero>> candidates = new Dictionary<int, List<Hero>>();
                    Dictionary<int, List<Hero>> heroList = heroesByFactionAndRarityAndId[faction]?[rarity];
                    foreach (int typeId in heroList.Keys)
                    {
                        if (heroList[typeId].Count > 1)
                        {
                            candidates[typeId] = heroList[typeId];
                        }
                    }


                }
                /*
                if (academy.Guardians.TryGetValue(faction, out factionData))
                {
                    GuardianData guardianData = null;
                    if (factionData.TryGetValue(hero.Type.Rarity, out guardianData))
                    {
                        foreach (var guardianSlot in guardianData.AssignedHeroes)
                        {
                            if (hero.Id == guardianSlot.FirstHero || hero.Id == guardianSlot.SecondHero)
                            {
                                return true;
                            }
                        }
                    }
                }*/
            }
        }
    }
}
