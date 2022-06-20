using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Guns.Settings
{
    public interface IRecoilProcessingSettings
    {
        AnimationCurve AnimationCurve {get;}
        float RecoilUnitsProcessedPerSecond {get;}
    }
}