using RimWorld;

namespace PollutionWweapons
{
    public sealed class CastAbility_Continuous : Verb_CastAbility
    {
        public override int ShotsPerBurst
        {
            get { return verbProps.burstShotCount; }
        }
    }
}
