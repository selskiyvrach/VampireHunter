using Selskiyvrach.Core.Unity.Transforms;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Gunslingers
{
    public class EyeSight : Rotator
    {
        public Ray GetLookRay() => 
            new Ray(transform.position, transform.forward);
    }
}