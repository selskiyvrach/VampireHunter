using UnityEngine;
using UnityEngine.Serialization;

namespace Selskiyvrach.VampireHunter.Combat.Aiming
{
    
    [CreateAssetMenu(menuName = "Configs/Aiming/AimingConstants", fileName = "AimingConstants", order = 0)]
    public class AimingConstants : ScriptableObject
    {
        [SerializeField]
        [Range(0, 999)]
        private int _maxDistance;
        
        [FormerlySerializedAs("_maxSpreadAngles")]
        [SerializeField]
        [Range(0, 45)]
        private int _maxSpreadAngle;
        
        public int MaxDistance => _maxDistance;
        public int MAXSpreadAngle => _maxSpreadAngle;
    }
}