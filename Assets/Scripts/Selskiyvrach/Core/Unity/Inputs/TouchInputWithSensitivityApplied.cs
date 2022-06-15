using UnityEngine;

namespace Selskiyvrach.Core.Unity.Inputs
{
    public class TouchInputWithSensitivityApplied : MonoBehaviour, ITouchInput
    {
        [SerializeField] private TouchInput _decorated;
        [SerializeField] private TouchSensitivitySettings _sensitivitySettings;
        
        public bool Started() => 
            _decorated.Started();

        public bool Held() => 
            _decorated.Held();

        public bool Finished() => 
            _decorated.Finished();

        public Vector2 Delta() => 
            _decorated.Delta() * _sensitivitySettings.Sensitivity;
    }
}