using UnityEngine;

namespace Selskiyvrach.Core.Unity.Transforms
{
    public interface ITransform
    {
        Vector3 Position { get; set; }
        Quaternion Rotation { get; set; }
        void SetParent(TransformAdapter parent);
    }
}