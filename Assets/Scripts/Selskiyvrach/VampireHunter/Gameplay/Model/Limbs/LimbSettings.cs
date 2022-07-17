using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Limbs
{
    [CreateAssetMenu(menuName = "Configs/Limbs/LimbSettings", fileName = "LimbSettings", order = 0)]
    public class LimbSettings : ScriptableObject, ILimbSettings
    { 
        [SerializeField] private float _damageCoefficient;
        [SerializeField] private float _severeDamageThreshold;
        
        public float DamageCoefficient => _damageCoefficient;
        public float SevereDamageThreshold => _severeDamageThreshold; 
    }
}