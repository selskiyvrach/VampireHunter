using Selskiyvrach.Core;
using Selskiyvrach.VampireHunter.Model.Guns;
using Selskiyvrach.VampireHunter.Test;
using UnityEngine;
using Ray = Selskiyvrach.Core.Math.Ray;

namespace Selskiyvrach.Test
{
    public class Test : MonoBehaviour, IBulletProvider, IBullet
    {
        [SerializeField] private TestTriggerFactory _triggerFactory;
        
        private Gun _gun;
        private void Start()
        {
            _gun = new Gun(
                new SimpleMagazine(this, 6), 
                new SimpleSight(), 
                _triggerFactory.Create());
        }
        
        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
                _gun.PullTheTrigger();
            
            if(Input.GetKeyDown(KeyCode.T))
                _gun.CockTheTrigger();
                    
            ((ITickable)_gun).Tick(Time.deltaTime);
        }

        private void LateUpdate()
        {
            _gun.OnAfterTick();
        }

        public IBullet GetBullet()
        {
            return this;
        }

        public IBullet SetTrajectory(Ray trajectory)
        {
            return this;
        }

        public IBullet Launch()
        {
            return this;
        }
    }
}