using UnityEngine;

namespace Selskiyvrach.VampireHunter
{
    public interface IGunInput
    {
        bool AimIsHeld();
        bool AimStarted();
        bool AimFinished();
        Vector2 AimDelta();
    }
}