using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Guns.Settings
{
    [CreateAssetMenu(menuName = "Configs/Guns/Settings/RecoilSettings", fileName = "recoil_settings", order = 0)]
    public class RecoilSettings : ScriptableObject, IRecoilSettings
    {
        [SerializeField] private int _recoil;

        public int Recoil => _recoil;
    }
}