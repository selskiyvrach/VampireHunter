using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Damaging
{
    public class HumanoidDamageModelSettings : ScriptableObject, IHumanoidDamageModelSettings
    {
        [SerializeField] private float _headDamageCoefficient;
        [SerializeField] private float _bodyDamageCoefficient;
        
        public float HeadDamageCoefficient => _headDamageCoefficient;
        public float BodyDamageCoefficient => _bodyDamageCoefficient;
    }
}