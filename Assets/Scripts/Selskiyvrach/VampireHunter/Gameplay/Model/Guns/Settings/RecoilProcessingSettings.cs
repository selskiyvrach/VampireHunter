using UnityEditor.Recorder;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Guns.Settings
{
    [CreateAssetMenu(menuName = "Configs/Guns/Settings/RecoilProcessingSettings", fileName = "recoil_processing_settings", order = 0)]
    public class RecoilProcessingSettings : ScriptableObject, IRecoilProcessingSettings
    {
        [SerializeField] private AnimationCurve _animationCurve;
        [SerializeField] private float _processingSpeed;
        
        public AnimationCurve AnimationCurve => _animationCurve;
        public float RecoilUnitsProcessedPerSecond => _processingSpeed;
    }
}