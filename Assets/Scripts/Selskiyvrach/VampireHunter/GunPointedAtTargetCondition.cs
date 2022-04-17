using Selskiyvrach.Core.StateMachines;
using UnityEngine;

namespace Selskiyvrach.VampireHunter
{
    public class GunPointedAtTargetCondition : ICondition
    {
        private readonly Camera _camera;
        private readonly RectTransform _aimScreenPoint;

        public GunPointedAtTargetCondition(RectTransform aimScreenPoint, Camera camera)
        {
            _aimScreenPoint = aimScreenPoint;
            _camera = camera;
        }

        public bool IsMet(StateMachine stateMachine)
        {
            var ray = _camera.ScreenPointToRay(_aimScreenPoint.position);
            var pointsAtTarget = Physics.Raycast(ray);
            return pointsAtTarget;
        }
    }
}