using Selskiyvrach.VampireHunter.Gameplay.Model.Creatures.Limbs;
using Selskiyvrach.VampireHunter.Gameplay.Model.Damaging;
using Selskiyvrach.VampireHunter.Gameplay.Model.Healths;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Creatures
{
    [CreateAssetMenu(menuName = "Configs/Creatures/Human/HumanSettings", fileName = "human_settings", order = 0)]
    public class HumanSettings : ScriptableObject
    {
        [SerializeField] private LimbDamageCoefficientSettings _headDamageCoeff;
        [SerializeField] private LimbDamageCoefficientSettings _bodyDamageCoeff;
        [SerializeField] private HealthSettings _healthSettings;
        [SerializeField] private float _speed;

        public IDamageCoefficient HeadDamageCoeff => _headDamageCoeff;
        public IDamageCoefficient BodyDamageCoeff => _bodyDamageCoeff;
        public IHealthSettings HealthSettings => _healthSettings;
        public float Speed => _speed;
    }
}