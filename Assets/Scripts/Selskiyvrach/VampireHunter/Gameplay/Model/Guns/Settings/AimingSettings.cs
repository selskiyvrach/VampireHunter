using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Guns.Settings
{
    
    [CreateAssetMenu(menuName = "Configs/Guns/Settings/AimingSettings", fileName = "aiming_settings", order = 0)]
    public class AimingSettings : ScriptableObject, IAimingSettings
    {
        [SerializeField] private float _accuracy; 
        [SerializeField] private float _hipAccuracy; 
        [SerializeField] private float _fromHipToAimedTime; 
        [SerializeField] private float _fromAimedToHipTime; 
        public float Accuracy => _accuracy;
        public float HipAccuracy => _hipAccuracy;
        public float FromHipToAimedTime => _fromHipToAimedTime;
        public float FromAimedToHipTime => _fromAimedToHipTime;
    }
}