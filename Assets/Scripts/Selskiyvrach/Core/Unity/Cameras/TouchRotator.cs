using Selskiyvrach.Core.Unity.Inputs;
using UnityEngine;
using UnityEngine.Serialization;

namespace Selskiyvrach.Core.Unity.Cameras
{
    public class TouchRotator : MonoBehaviour
    {
        [FormerlySerializedAs("_cameraMover")] [SerializeField] private Rotator _rotator;
        [SerializeField] private TouchInput _mouseTouchInput;

        private void LateUpdate()
        {
            if(_mouseTouchInput.Held())
                _rotator.RotateLook(_mouseTouchInput.Delta());
        }
    }
}