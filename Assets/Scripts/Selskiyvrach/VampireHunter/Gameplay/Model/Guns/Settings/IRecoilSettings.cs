using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Guns.Settings
{
    public interface IRecoilSettings
    {
        AnimationCurve AnimationCurve {get;}
        float RecoilUnitsProcessedPerSecond {get;}
        int Recoil {get;}
    }
}