using Selskiyvrach.VampireHunter.View.Collisions;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.View.Combat
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Raycaster _raycaster;
        [SerializeField] private BulletTargetTriggerCallback _bulletTargetCallback;
        private Ray _trajectory;
        private float _speed;

        private void Awake() =>
            _bulletTargetCallback.OnEntered += OnHit;

        private void OnDestroy() =>
            _bulletTargetCallback.OnEntered += OnHit;

        private void OnHit(BulletTarget obj)
        {
            Debug.Log("Bullet hit target");
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

        private void FixedUpdate()
        {
            // raycast to see if the way is clear
            // move along trajectory for full distance or up to casted target
        }

        public void Launch(Ray trajectory, float speed)
        {
            _trajectory = trajectory;
            _speed = speed;
        }
    }
}