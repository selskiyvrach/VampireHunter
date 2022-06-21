using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Guns.Settings
{
    [CreateAssetMenu(menuName = "Configs/Guns/HandRecoilProcessingSettings", fileName = "hand_recoil_processing_settings", order = 0)]
    public class HandRecoilProcessingSettings : RecoilProcessingSettings, IHandRecoilProcessingSettings
    {
    }
}