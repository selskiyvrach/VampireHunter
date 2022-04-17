using UnityEngine;

namespace Selskiyvrach.VampireHunter
{
    public interface ICrosshair
    {
        RectTransform ScreenPos { get; }
        bool Idled { get; }
        bool Aimed { get; }
        void TransitionToRecoil();
        void TransitionToIdle();
        void TransitionToAimed();
    }
}