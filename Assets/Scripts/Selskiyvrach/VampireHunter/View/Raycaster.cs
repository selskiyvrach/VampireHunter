using UnityEngine;

namespace Selskiyvrach.VampireHunter.View
{
    public class Raycaster : MonoBehaviour
    {
        public bool Raycast(Ray ray)
        {
            return Physics.Raycast(ray);
        }
    }
}