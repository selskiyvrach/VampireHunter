using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Healths
{
    [CreateAssetMenu(menuName = "Configs/Health/HealthSettings", fileName = "health_settings", order = 0)]
    public class HealthSettings : ScriptableObject, IHealthSettings
    {
        [SerializeField] private int _maxHealth;
        public int MaxHealth => _maxHealth;
    }
}