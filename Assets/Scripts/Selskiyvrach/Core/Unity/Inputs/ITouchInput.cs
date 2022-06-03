using UnityEngine;

namespace Selskiyvrach.Core.Unity.Inputs
{
    public interface ITouchInput
    {
        bool Started();
        bool Held();
        bool Finished();
        Vector2 Delta();
    }
}