using UnityEngine;

namespace Selskiyvrach.VampireHunter.Model.Aiming
{
    [CreateAssetMenu(fileName = "AimingSettings", menuName = "Configs/Combat/AimingSettings", order = 0)]
    public class AimingSettings : ScriptableObject
    {
        [SerializeField] private Vector2 _crosshairScreenPosNormalized;
        [SerializeField] private int _maxAimingDistance;
        [SerializeField] private int _maxSpreadDegrees;
                
        public Vector2 CrosshairScreenPosNormalized => _crosshairScreenPosNormalized;
        public int MaxAimingDistance => _maxAimingDistance;
        public int MaxSpreadDegrees => _maxSpreadDegrees;
    }
}
