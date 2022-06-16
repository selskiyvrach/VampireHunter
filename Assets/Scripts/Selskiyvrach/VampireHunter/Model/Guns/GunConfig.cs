using UnityEngine;

namespace Selskiyvrach.VampireHunter.Model.Guns
{
    [CreateAssetMenu(menuName = "Configs/Guns/GunConfig", fileName = "GunConfig", order = 0)]
    public class GunConfig : ScriptableObject
    {
        [SerializeField] private GunDefinition _definition;
        [SerializeField] private GunStats _stats;
        [SerializeField] private int _ammo;
        public GunStats Stats => _stats;
        public int Ammo => _ammo;
        public GunDefinition GunDefinition => _definition;
    }
}