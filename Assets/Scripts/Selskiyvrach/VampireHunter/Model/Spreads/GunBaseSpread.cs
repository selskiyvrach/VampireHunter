using Selskiyvrach.VampireHunter.Model.Guns;

namespace Selskiyvrach.VampireHunter.Model.Spreads
{
    public class GunBaseSpread : StaticSpread
    {
        public GunBaseSpread(Gun gun) : base(gun.Stats.Accuracy)
        {
        }
    }
}