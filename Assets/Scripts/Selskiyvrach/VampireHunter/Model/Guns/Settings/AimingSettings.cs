using UnityEngine;

namespace Selskiyvrach.VampireHunter.Model.Guns.Settings
{
    
    [CreateAssetMenu(menuName = "Configs/Guns/Settings/AimingSettings", fileName = "aiming_settings", order = 0)]
    public class AimingSettings : ScriptableObject, IAimingSettings
    {
        [SerializeField] private float _accuracy; 
        [SerializeField] private float _hipAccuracy; 
        [SerializeField] private float _fromHipToAimedTime; 
        [SerializeField] private float _fromAimedToHipTime; 
        public float HipAccuracy => _accuracy;
        public float FromHipToAimedTime => _hipAccuracy;
        public float FromAimedToHipTime => _fromHipToAimedTime;
        public float Accuracy => _fromAimedToHipTime;
    }
}