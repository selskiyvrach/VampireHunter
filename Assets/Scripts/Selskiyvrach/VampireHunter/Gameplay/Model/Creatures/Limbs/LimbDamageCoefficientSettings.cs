using Selskiyvrach.VampireHunter.Gameplay.Model.Damaging;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Creatures.Limbs
{
    
    [CreateAssetMenu(menuName = "Configs/Creatures/LimbDamageCoefficientSettings", fileName = "limb_damage_coefficient_settings", order = 0)]
    public class LimbDamageCoefficientSettings : ScriptableObject, IDamageCoefficient
    {
        [MinValue(0)][SerializeField] private float _coefficient;
        public float Coefficient => _coefficient;
    }
}