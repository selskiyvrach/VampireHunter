using UnityEngine;

namespace Selskiyvrach.VampireHunter.View.Combat
{
    public class Barrel : MonoBehaviour
    {
        [SerializeField]
        private Transform _bulletStartPoint;
        public Transform BulletStartPoint => _bulletStartPoint;
    }
}