using UnityEngine;

namespace Selskiyvrach.VampireHunter.Model.Guns
{
    [CreateAssetMenu(menuName = "Configs/Guns/Stats/GunStats", fileName = "GunStats", order = 0)]
    public class GunStats : ScriptableObject, IGunStats 
    {
        [SerializeField] private float _damage;
        [SerializeField] private float _accuracy;
        [SerializeField] private float _recoil;
        [SerializeField] private float _aimTime;
        [SerializeField] private float _cockTriggerTime;
        [SerializeField] private float _hipTime;
        [SerializeField] private float _reloadTime;

        public float Damage => _damage;
        public float Accuracy => _accuracy;
        public float Recoil => _recoil;
        public float AimTime => _aimTime;
        public float CockTriggerTime => _cockTriggerTime;
        public float HipTime => _hipTime;
        public float ReloadTime => _reloadTime;
    }
}