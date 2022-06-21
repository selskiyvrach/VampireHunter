using Selskiyvrach.Core.Unity.Transforms;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Gunslingers
{
    public class Eyes : Rotator
    {
        public Ray GetLookRay() => 
            new Ray(transform.position, transform.forward);

        public void SetCamera(Camera cam) => 
            cam.transform.SetParent(transform, false);
    }
}