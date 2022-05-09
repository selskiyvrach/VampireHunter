using UnityEngine;

namespace Selskiyvrach.VampireHunter.View.Combat
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