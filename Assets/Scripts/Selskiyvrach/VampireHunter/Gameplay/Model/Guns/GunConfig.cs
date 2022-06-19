using Selskiyvrach.VampireHunter.Gameplay.Model.Guns.Settings;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Guns
{
    [CreateAssetMenu(menuName = "Configs/Guns/GunConfig", fileName = "GunConfig", order = 0)]
    public class GunConfig : ScriptableObject
    {
        [SerializeField] private GunSettings _settings;
        [SerializeField] private int _ammo;
        public GunSettings Settings => _settings;
        public int Ammo => _ammo;
    }
}