using Selskiyvrach.VampireHunter.Controller;
using Selskiyvrach.VampireHunter.Model.Guns;
using Selskiyvrach.VampireHunter.Model.Gunslingers;
using Selskiyvrach.VampireHunter.View;
using UnityEngine;
using Ray = Selskiyvrach.Core.Math.Ray;

namespace Selskiyvrach.VampireHunter.Test
{
    public class Test : MonoBehaviour, IBulletProvider, IBullet
    {
        [SerializeField] private TestTriggerFactory _triggerFactory;
        [SerializeField] private Raycaster _raycaster;
        [SerializeField] private CrosshairAnimationsPlayer _crosshairAnimationsPlayer;
        [SerializeField] private ScreenPointAsRay _screenPointAsRay;
        
        private Gun _gun;
        private Gunslinger _gunslinger;
        
        private void Start()
        {
            _gun = new Gun(
                new SimpleMagazine(this, 6), 
                new Sight(new SightAdapter(_screenPointAsRay)), 
                _triggerFactory.Create(),
                new RaycasterAdapter(_raycaster));
            
            _gunslinger = new Gunslinger
                (
                    _gun,
                    new ActionAnimationStarterAdapter(() => _crosshairAnimationsPlayer.PlayAim()),
                    new AnimationCallbackAdapter(_crosshairAnimationsPlayer.OnAimed),
                    new ActionAnimationStarterAdapter(() => _crosshairAnimationsPlayer.PlayIdle()),
                    new AnimationCallbackAdapter(_crosshairAnimationsPlayer.OnIdled),
                    new ActionAnimationStarterAdapter(() => _crosshairAnimationsPlayer.PlayRecoil()),
                    new AnimationCallbackAdapter(_crosshairAnimationsPlayer.OnRecoilFinished),
                    new GunslingerInputAdapter(() => Input.GetMouseButton(0), () => Input.GetKey(KeyCode.R))
                );
        }
        
        private void Update()
        {
            _gunslinger.Tick(Time.deltaTime);
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