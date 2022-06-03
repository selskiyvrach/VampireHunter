using Selskiyvrach.VampireHunter.Model.Combat;

namespace Selskiyvrach.VampireHunter.Model.Guns
{
    public class Bullet : IBullet
    {
        public Damage Damage { get; private set; }

        public Bullet(Damage ownDamage) =>
            Damage = ownDamage;
        
        public void Launch(BulletLaunchData launchData) => 
            Damage = new Damage(launchData.Damage.Value + Damage.Value);
    }
}