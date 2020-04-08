﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.CampaignBehaviors;
using TaleWorlds.Localization;

namespace Banditlord.Spawn
{
    class DailyBanditSpawnBehaviour : CampaignBehaviorBase
    {
        public override void RegisterEvents()
        {
            CampaignEvents.DailyTickEvent.AddNonSerializedListener(this, BanditSpawnBehaviour);
        }

        public override void SyncData(IDataStore dataStore)
        {

        }

        public void BanditSpawnBehaviour()
        {
            SpawnBanditAtRandomHideout();
        }

        private void SpawnBanditAtRandomHideout()
        {
            try
            {
                Clan clan = CampaignUtils.GetClanWithName("Mountain Bandits");
                Spawner.SpawnBanditAtHideout(CampaignUtils.GetPreferableHideout(clan), clan, clan.DefaultPartyTemplate, new TextObject("Mountain Raiders"));
            }
            catch(Exception e)
            {
                ErrorHandler.HandleException(e);
            }
        }
    }
}
