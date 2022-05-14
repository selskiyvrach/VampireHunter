using Sirenix.OdinInspector;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Unity.Combat
{
    public class CrosshairRadiusProvider : CrosshairRadiusProviderBase
    {
        [SerializeField] private bool _useEditorValue;
        [ShowIf(nameof(_useEditorValue))][SerializeField] [MinValue(0)] private float _radius;

        public ICrosshairRadius CrosshairRadius { get; set; }

        public override float Radius => _useEditorValue ? _radius : CrosshairRadius.Radius;
    }
}