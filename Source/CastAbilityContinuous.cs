using RimWorld;

namespace PollutionWweapons
{
    public sealed class CastAbility_Continuous : Verb_CastAbility
    {
        protected override int ShotsPerBurst
        {
            get { return verbProps.burstShotCount; }
        }
    }
}
