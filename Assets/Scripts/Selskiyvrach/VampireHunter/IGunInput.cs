using UnityEngine;

namespace Selskiyvrach.VampireHunter
{
    public interface IGunInput
    {
        bool AimIsHeld();
        bool AimStarted();
        bool AimIsFinished();
        Vector2 AimDelta();
    }
}