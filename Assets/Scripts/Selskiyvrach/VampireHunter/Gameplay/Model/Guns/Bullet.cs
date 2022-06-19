using Selskiyvrach.VampireHunter.Gameplay.Model.Damaging;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Guns
{
    public class Bullet : IBullet
    {
        public Damage Damage { get; private set; }
        
        public void Launch(BulletLaunchData launchData) => 
            Damage = new Damage(launchData.Damage.Value);
    }
}