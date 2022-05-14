using UnityEngine;

namespace Selskiyvrach.VampireHunter.Unity.Combat
{
    public abstract class CrosshairRadiusProviderBase : MonoBehaviour
    {
        public abstract float Radius { get; }
    }
}