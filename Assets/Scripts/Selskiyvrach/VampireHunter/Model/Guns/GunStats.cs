using UnityEngine;

namespace Selskiyvrach.VampireHunter.Model.Guns
{
    [CreateAssetMenu(menuName = "Configs/Guns/Stats/GunStats", fileName = "GunStats", order = 0)]
    public class GunStats : ScriptableObject, IGunStats 
    {
        [SerializeField] private float _damage;
        [SerializeField] private float _accuracy;
        [SerializeField] private float _recoil;
        [SerializeField] private float _cockTriggerTime;
        [SerializeField] private float _hipTime;
        [SerializeField] private float _reloadTime;
        [SerializeField] private float _hipAccuracy;   
        [SerializeField] private float _fromHipToAimedDuration;   
        [SerializeField] private float _fromAimedToHipTimeDuration;   

        public float Damage => _damage;
        public float Accuracy => _accuracy;
        public float Recoil => _recoil;
        public float CockTriggerTime => _cockTriggerTime;
        public float HipTime => _hipTime;
        public float ReloadTime => _reloadTime;
        public float HipAccuracy => _hipAccuracy;
        public float FromHipToAimedTime => _fromHipToAimedDuration;
        public float FromAimedToHipTime => _fromAimedToHipTimeDuration;
    }
}