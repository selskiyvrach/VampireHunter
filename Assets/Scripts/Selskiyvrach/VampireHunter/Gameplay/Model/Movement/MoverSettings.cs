using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Movement
{
    [CreateAssetMenu(menuName = "Configs/Movement/MoverSettings", fileName = "MoverSettings", order = 0)]
    public class MoverSettings : ScriptableObject, IMoverSettings
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _stoppingDistance;
        
        public float Speed => _speed;
        public float StoppingDistance => _stoppingDistance;
    }
}