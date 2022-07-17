using UnityEngine;

namespace Selskiyvrach.Core.Unity.Transforms
{
    public class WorldObject : ITransform
    {
        private readonly Transform _transform;
        private WorldObject _parent;

        public Vector3 Position
        {
            get => _transform.position; 
            set => _transform.position = value;
        }

        public Quaternion Rotation
        {
            get => _transform.rotation; 
            set => _transform.rotation = value;
        }

        public WorldObject(Transform transform) => 
            _transform = transform;

        public void SetParent(WorldObject parent)
        {
            _parent = parent;
            _transform.SetParent(parent._transform);
        }
    }
}