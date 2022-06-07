using Selskiyvrach.Core.Unity.Cameras;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Model.Gunslingers
{
    public class EyeSight : Rotator
    {
        public Ray GetLookRay() => 
            new Ray(transform.position, transform.forward);
    }
}