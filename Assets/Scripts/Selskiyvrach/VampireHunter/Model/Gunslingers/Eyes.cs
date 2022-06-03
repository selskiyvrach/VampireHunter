using UnityEngine;

namespace Selskiyvrach.VampireHunter.Model.Gunslingers
{
    public class Eyes : MonoBehaviour
    {
        [SerializeField]
        private Transform _eyes;

        public Ray GetLookRay() => 
            new Ray(_eyes.position, _eyes.forward);
    }
}