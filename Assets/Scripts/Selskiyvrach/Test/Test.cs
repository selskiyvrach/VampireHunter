using Selskiyvrach.Core;
using Selskiyvrach.VampireHunter.Combat.Guns;
using UnityEngine;
using Ray = Selskiyvrach.Core.Math.Ray;

namespace Selskiyvrach.Test
{
    public class Test : MonoBehaviour, IBulletProvider, IBullet
    {
        private Gun _gun;
        private void Start()
        {
            _gun = new Gun(
                new SimpleMagazine(this, 6), 
                new SimpleSight(), 
                new SimpleTrigger());
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
            ((ILateTickable)_gun).Tick(Time.deltaTime);
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