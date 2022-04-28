using UnityEngine;

namespace Selskiyvrach.VampireHunter.Combat.Aiming
{
    [CreateAssetMenu(menuName = "Configs/Aiming/SpreadCalculator", fileName = "SpreadCalculator", order = 0)]
    public class SpreadCalculator : ScriptableObject
    {
        [SerializeField] 
        private AimingConstants _aimingConstants;
        
        public void AddSpread(ref Vector3 direction, int accuracy)
        {
            
        }
    }
}