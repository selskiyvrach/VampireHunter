using Selskiyvrach.Core.Unity.Cameras;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Model.Gunslingers
{
    public class EyeSight : Rotator
    {
        private readonly Transform _eyesTransform;

        public Ray GetLookRay() => 
            new Ray(_eyesTransform.position, _eyesTransform.forward);
    }
}