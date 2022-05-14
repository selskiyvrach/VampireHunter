using UnityEngine;

namespace Selskiyvrach.VampireHunter.Unity.Combat
{
    public class BulletFactory : MonoBehaviour
    {
        [SerializeField] private Bullet _prefab;

        public Bullet Create() =>
            Instantiate(_prefab, transform);
    }

    public class ProjectileFinalPointFinder : MonoBehaviour
    {
            
    }
}