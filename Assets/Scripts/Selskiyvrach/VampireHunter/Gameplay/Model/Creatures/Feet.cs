using Selskiyvrach.Core.Tickers;
using Selskiyvrach.Core.Unity.Transforms;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Creatures
{
    public class Feet : IMover, ITickable
    {
        private readonly ITransform _transform;
        private readonly float _speed;
        private Vector3 _targetPos;

        public Feet(ITransform transform, float speed)
        {
            _transform = transform;
            _speed = speed;
        }

        public void MoveTowards(Vector3 position) => 
            _targetPos = position;

        public void Tick(float deltaTime) => 
            _transform.Position = Vector3.MoveTowards(_transform.Position, new Vector3(_targetPos.x, 0, _targetPos.z), _speed * deltaTime);
    }
}