using Raid.Toolkit.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hero_Manager.Data_Model
{
    internal class HMAccountData
    {
        public static async Task<Account[]> GetAccounts(IAccountApi accountApi)
        {
            return await accountApi.GetAccounts();
        }

        public static async Task<HMAccountData> Get(IAccountApi accountApi, Account account)
        {
            AcademyData academyData = await accountApi.GetAcademy(account.Id);
            ArenaData arenaData = await accountApi.GetArena(account.Id);
            Artifact[] artifacts = await accountApi.GetArtifacts(account.Id);
            Hero[] heroes = await accountApi.GetHeroes(account.Id);
            Resources resources = await accountApi.GetAllResources(account.Id);

            return new HMAccountData(academyData, arenaData, artifacts, heroes, resources);
        }

        private AcademyData acadamyData;
        private ArenaData arenaData;
        private Artifact[] artifacts;
        private Hero[] heroes;
        private Resources resources;

        private HMAccountData(AcademyData acadamyData, ArenaData arenaData, Artifact[] artifacts, Hero[] heroes, Resources resources)
        {
            this.acadamyData = acadamyData;
            this.arenaData = arenaData;
            this.artifacts = artifacts;
            this.heroes = heroes;
            this.resources = resources;
        }

        public IEnumerable<Hero> GetLiveHeroes()
        {
            foreach (Hero hero in this.heroes)
            {
                if (hero.Deleted)
                    continue;

                yield return hero;
            }
        }

        public IEnumerable<Artifact> GetLiveArtifacts()
        {
            foreach (Artifact artifact in  this.artifacts)
            {
                yield return artifact;
            }
        }
    }
}
