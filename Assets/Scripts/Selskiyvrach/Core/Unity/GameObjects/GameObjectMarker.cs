using UnityEngine;

namespace Selskiyvrach.Core.Unity.GameObjects
{
    public abstract class GameObjectMarker : MonoBehaviour
    {
        
    }

    public abstract class GameObjectMarker<T> : GameObjectMarker where T : class 
    {
        
    }
}