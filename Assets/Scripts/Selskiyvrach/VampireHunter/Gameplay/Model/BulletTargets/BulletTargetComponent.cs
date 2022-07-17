using System.Collections.Generic;
using System.Threading.Tasks;
using Selskiyvrach.VampireHunter.Gameplay.Model.Bullets;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.BulletTargets
{
    public abstract class BulletTargetComponent : MonoBehaviour, IBulletTarget, IBulletTargetComponent
    {
        [SerializeField] private Collider _collider;
        private readonly HashSet<IBulletTarget> _bulletTargets = new HashSet<IBulletTarget>();

        public void GetHitBy(IBullet bullet)
        {
            foreach (var target in _bulletTargets)
                target.GetHitBy(bullet);
        }

        public bool AddBulletTarget(IBulletTarget target) => 
            _bulletTargets.Add(target);

        public bool RemoveBulletTarget(IBulletTarget target) => 
            _bulletTargets.Remove(target);

        public Task Initialize() => 
            Task.CompletedTask;

        public void Enable() =>
            _collider.enabled = true;

        public void Disable() => 
            _collider.enabled = false;

        public Task ReleaseResources() => 
            Task.CompletedTask;
    }
}