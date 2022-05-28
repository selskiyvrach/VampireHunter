using Selskiyvrach.VampireHunter.Unity.Collisions;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Unity.Combat
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Raycaster _raycaster;
        [SerializeField] private BulletTargetTriggerCallback _bulletTargetCallback;
        private Ray _trajectory;
        private float _speed = 1000;

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
            var position = transform.position;
            var scanResult = _raycaster.Raycast<BulletTarget>(new Ray(position, _trajectory.direction), _speed);
            if (scanResult.Target != null)
                transform.position = scanResult.Point;
            else
                transform.position += _trajectory.direction.normalized * (_speed * Time.fixedDeltaTime);
        }

        public void Launch(Ray trajectory) => 
            _trajectory = trajectory;
    }
}