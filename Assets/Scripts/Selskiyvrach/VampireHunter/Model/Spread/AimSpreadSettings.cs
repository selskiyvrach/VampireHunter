using UnityEngine;

namespace Selskiyvrach.VampireHunter.Model.Spread
{
    [CreateAssetMenu(menuName = "Configs/Aiming/AimSpreadSettings", fileName = "AimSpreadSettings", order = 0)]
    public class AimSpreadSettings : ScriptableObject
    {
        [SerializeField] private float _spreadWhenAimedCoefficient;
        [SerializeField] private float _fromNotAimedToFullyAimedDuration;
        [SerializeField] private float _fromAimedToNotAimedDuration;
        
        public float SpreadWhenAimedCoefficient => _spreadWhenAimedCoefficient;
        public float FromNotAimedToFullyAimedDuration => _fromNotAimedToFullyAimedDuration;
        public float FromAimedToNotAimedDuration => _fromAimedToNotAimedDuration;
    }
}