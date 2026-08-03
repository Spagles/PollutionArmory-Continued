using RimWorld;
using UnityEngine;
using Verse;

namespace PollutionWweapons
{
    public sealed class Projectile_WR : Projectile_Explosive
    {
        private int ticksToDetonation;

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref ticksToDetonation, "ticksToDetonation", 0);
        }

        protected override void Impact(Thing hitThing, bool blockedByShield = false)
        {
            if (blockedByShield || def.projectile.explosionDelay == 0)
            {
                Explode();
                return;
            }

            landed = true;
            ticksToDetonation = Mathf.CeilToInt(Rand.Range(
                def.projectile.explosionDelay / 1.5f,
                def.projectile.explosionDelay * 1.5f));
            GenExplosion.NotifyNearbyPawnsOfDangerousExplosive(this, def.projectile.damageDef);
        }

        protected override void Explode()
        {
            Map map = Map;
            if (def.projectile.explosionEffect != null)
            {
                Effecter effecter = def.projectile.explosionEffect.Spawn();
                effecter.Trigger(new TargetInfo(Position, map), new TargetInfo(Position, map));
                effecter.Cleanup();
            }

            PollutionUtility.GrowPollutionAt(Position, map, 1);
            base.Explode();
        }

        protected override void Tick()
        {
            base.Tick();
            if (ticksToDetonation > 0 && --ticksToDetonation <= 0)
            {
                Explode();
            }
        }

        public override void SpawnSetup(Map map, bool respawningAfterLoad)
        {
            base.SpawnSetup(map, respawningAfterLoad);
            if (!respawningAfterLoad)
            {
                Impact(null);
            }
        }
    }
}
