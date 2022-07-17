using UnityEngine;

namespace Selskiyvrach.Core.Unity.Transforms
{
    public interface ITransform
    {
        public Quaternion Rotation { get; set; }
        public Vector3 Position { get; set; }
    }
}