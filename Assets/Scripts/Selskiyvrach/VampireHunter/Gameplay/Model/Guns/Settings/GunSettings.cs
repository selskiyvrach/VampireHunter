using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Guns.Settings
{
    [CreateAssetMenu(menuName = "Configs/Guns/Settings/GunSettings", fileName = "gun_settings", order = 0)]
    public class GunSettings : ScriptableObject, IGunSettings 
    {
        [SerializeField] private float _damage;
        [SerializeField] private RecoilSettings _recoilSettings;
        [SerializeField] private AimingSettings _globalAimingSettings;
        [SerializeField] private MagazineSettings _magazineSettings;

        public float Damage => _damage;
        public IRecoilSettings RecoilSettings => _recoilSettings;
        public IAimingSettings AimingSettings => _globalAimingSettings;
        public IMagazineSettings MagazineSettings => _magazineSettings;
    }
}