using UnityEngine;

namespace Selskiyvrach.Core.Unity.Inputs
{
    [CreateAssetMenu(menuName = "Configs/Input/TouchSensitivitySettings", fileName = "TouchSensitivitySettings", order = 0)]
    public class TouchSensitivitySettings : ScriptableObject
    {
        [SerializeField] private float _sensitivity;
        public float Sensitivity => _sensitivity;
    }
}