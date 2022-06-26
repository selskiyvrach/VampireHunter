using Selskiyvrach.Core.Unity.Transforms;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Gunslingers
{
    public class Eyes : Rotator
    {
        private TransformAdapter _transform;
        
        public ITransform Transform => _transform ??= new TransformAdapter(transform);

        public Ray GetLookRay() => 
            new Ray(transform.position, transform.forward);

        public void SetCamera(Camera cam) => 
            cam.transform.SetParent(transform, false);
    }
}