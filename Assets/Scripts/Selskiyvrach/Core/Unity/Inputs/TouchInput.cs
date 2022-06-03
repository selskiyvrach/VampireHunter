using UnityEngine;

namespace Selskiyvrach.Core.Unity.Inputs
{
    public abstract class TouchInput : MonoBehaviour, ITouchInput
    {
        public abstract bool Started();
        public abstract bool Held();
        public abstract bool Finished();
        public abstract Vector2 Delta();
    }
}