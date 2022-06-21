using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Guns.Settings
{
    [CreateAssetMenu(menuName = "Configs/Guns/SpreadRecoilProcessingSettings", fileName = "spread_recoil_processing_settings", order = 0)]
    public class SpreadRecoilProcessingSettings : RecoilProcessingSettings, ISpreadRecoilProcessingSettings
    {
    }
}