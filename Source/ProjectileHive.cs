using RimWorld;
using Verse;

namespace PollutionWweapons
{
    public sealed class Projectile_Hive : Projectile_Explosive
    {
        protected override void Explode()
        {
            PollutionUtility.GrowPollutionAt(Position, Map, 7);
            base.Explode();
        }
    }
}
