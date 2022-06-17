using UnityEngine;

namespace Selskiyvrach.VampireHunter.Model.Guns.Settings
{
    [CreateAssetMenu(menuName = "Configs/Guns/Settings/MagazineSettings", fileName = "magazine_settings", order = 0)]
    public class MagazineSettings : ScriptableObject, IMagazineSettings
    {
        [SerializeField] private int _capacity;
        public int Capacity => _capacity;
    }
}