using UnityEngine;

namespace Selskiyvrach.VampireHunter.Unity
{
    
    [CreateAssetMenu(menuName = "Configs/Guns/Stats/GunStats", fileName = "GunStats", order = 0)]
    public class GunStats : ScriptableObject
    {
        [SerializeField] private int _damage;
        [SerializeField] private int _accuracy;
        [SerializeField] private int _bulletSpeed;
        [SerializeField] private int _recoil;

        public int Damage => _damage;
        public int Accuracy => _accuracy;
        public int BulletSpeed => _bulletSpeed;
        public int Recoil => _recoil;
    }
}