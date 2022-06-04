using UnityEngine;

namespace Selskiyvrach.VampireHunter.Model.Gunslingers
{
    public class Eyes
    {
        private readonly EyesGameObject _eyes;
        private readonly Transform _eyesTransform;

        public Eyes(EyesGameObject eyes)
        {
            _eyes = eyes;
            _eyesTransform = _eyes.transform;
        }

        public Ray GetLookRay() => 
            new Ray(_eyesTransform.position, _eyesTransform.forward);
    }
}