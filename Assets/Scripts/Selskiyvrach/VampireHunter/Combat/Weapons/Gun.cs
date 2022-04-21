using Selskiyvrach.VampireHunter.Combat.Health;

namespace Selskiyvrach.VampireHunter.Combat.Weapons
{
    public class Gun
    {
        private readonly IMagazine _magazine;
        private Shot _shot;

        public Gun(IMagazine magazine)
        {
            _magazine = magazine;
        }

        public void Shoot()
        {
            _shot = new Shot(_magazine.BulletToBarrel());
        }
    }

    public interface IMagazine
    {
        int Capacity { get; }
        void Load(IBullet bullet);
        IBullet BulletToBarrel();
    }

    public interface IDamageInfo
    {
        Damage Damage { get; }
    }

    public class Shot
    {
        private readonly IBullet _bullet;
        
        public Shot(IBullet bullet)
        {
            _bullet = bullet;
            _bullet.OnHit += OnTargetHit;
        }

        private void OnTargetHit(IDamageable damageable)
        {
            damageable.TakeDamage(_bullet.Damage);
        }
    }

    public interface IBullet : IDamageInfo
    {
        OnHit OnHit { get; set; }
    }

    public delegate void OnHit(IDamageable damageable);
}