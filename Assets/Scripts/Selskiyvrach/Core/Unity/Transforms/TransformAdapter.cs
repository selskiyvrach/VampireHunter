using UnityEngine;

namespace Selskiyvrach.Core.Unity.Transforms
{
    public class TransformAdapter : ITransform
    {
        private readonly Transform _transform;
        private ITransform _parent;

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
        
        public void SetParent(TransformAdapter parent)
        {
            _parent = parent;
            _transform.SetParent(parent._transform);
        }

        public TransformAdapter(Transform transform) => 
            _transform = transform;
    }
}