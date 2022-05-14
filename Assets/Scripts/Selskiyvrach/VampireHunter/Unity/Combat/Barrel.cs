using UnityEngine;

namespace Selskiyvrach.VampireHunter.Unity.Combat
{
    public class Barrel : MonoBehaviour
    {
        [SerializeField]
        private Transform _bulletStartPoint;
        public Transform BulletStartPoint => _bulletStartPoint;
    }
}