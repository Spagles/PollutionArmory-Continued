using CombatExtended;
using RimWorld;
using UnityEngine;
using Verse;

namespace PollutionWeaponsCE
{
    public sealed class CastAbilityContinuousCE : Verb_AbilityShootCE
    {
        public override int ShotsPerBurst
        {
            get { return verbProps.burstShotCount; }
        }
    }

    public sealed class ProjectileHiveCE : ProjectileCE_Explosive
    {
        private bool pollutionApplied;

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref pollutionApplied, "pollutionApplied", false);
        }

        public override void Impact(Thing hitThing)
        {
            if (def.projectile.explosionDelay == 0)
            {
                ApplyPollution();
            }

            base.Impact(hitThing);
        }

        public override void Tick()
        {
            if (ticksToDetonation == 1)
            {
                ApplyPollution();
            }

            base.Tick();
        }

        private void ApplyPollution()
        {
            if (pollutionApplied || Map == null)
            {
                return;
            }

            pollutionApplied = true;
            PollutionUtility.GrowPollutionAt(Position, Map, 7);
        }
    }

    public sealed class ProjectileResidueCE : ProjectileCE_Explosive
    {
        private bool pollutionApplied;

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref pollutionApplied, "pollutionApplied", false);
        }

        public override void SpawnSetup(Map map, bool respawningAfterLoad)
        {
            base.SpawnSetup(map, respawningAfterLoad);
            if (!respawningAfterLoad)
            {
                Impact(null);
            }
        }

        public override void Impact(Thing hitThing)
        {
            if (def.projectile.explosionDelay == 0)
            {
                ApplyPollution();
            }

            base.Impact(hitThing);

            if (ticksToDetonation > 0)
            {
                ticksToDetonation = Mathf.CeilToInt(Rand.Range(
                    def.projectile.explosionDelay / 1.5f,
                    def.projectile.explosionDelay * 1.5f));
            }
        }

        public override void Tick()
        {
            if (ticksToDetonation == 1)
            {
                ApplyPollution();
            }

            base.Tick();
        }

        private void ApplyPollution()
        {
            if (pollutionApplied || Map == null)
            {
                return;
            }

            pollutionApplied = true;
            PollutionUtility.GrowPollutionAt(Position, Map, 1);
        }
    }
}
