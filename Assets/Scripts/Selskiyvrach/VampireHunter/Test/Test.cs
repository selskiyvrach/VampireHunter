using System.Collections.Generic;
using Selskiyvrach.VampireHunter.Controller;
using Selskiyvrach.VampireHunter.Model.Guns;
using Selskiyvrach.VampireHunter.Model.Gunslingers;
using Selskiyvrach.VampireHunter.View;
using Selskiyvrach.VampireHunter.View.Animations;
using Selskiyvrach.VampireHunter.View.Combat;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Test
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private TestTriggerFactory _triggerFactory;
        [SerializeField] private Raycaster _raycaster;
        [SerializeField] private CrosshairAnimationsPlayer _crosshairAnimationsPlayer;
        [SerializeField] private ScreenPointAsRay _screenPointAsRay;
        [SerializeField] private RecoilAnimationPlayer _camRecoilPlayer;
        [SerializeField] private RecoilAnimationPlayer _gunRecoilPlayer;
        [SerializeField] private BulletFactory _bulletFactory;

        private Gun _gun;
        private Gunslinger _gunslinger;

        private void Start()
        {
            var magazine = new Magazine(6);
            var bullets = new []
            {
                new BulletAdapter(_bulletFactory.Create()),
                new BulletAdapter(_bulletFactory.Create()),
                new BulletAdapter(_bulletFactory.Create()),
                new BulletAdapter(_bulletFactory.Create()),
                new BulletAdapter(_bulletFactory.Create()),
                new BulletAdapter(_bulletFactory.Create()),
            };
            magazine.Push(bullets);
            
            _gun = new Gun(
                magazine, 
                new Sight(new SightAdapter(_screenPointAsRay)), 
                _triggerFactory.Create(),
                new RaycasterAdapter(_raycaster), 100);
            
            _gunslinger = new Gunslinger
                (
                    _gun,
                    new ActionAnimationStarterAdapter(() => _crosshairAnimationsPlayer.PlayAim()),
                    new AnimationCallbackAdapter(_crosshairAnimationsPlayer.OnAimed),
                    new ActionAnimationStarterAdapter(() => _crosshairAnimationsPlayer.PlayIdle()),
                    new AnimationCallbackAdapter(_crosshairAnimationsPlayer.OnIdled),
                    new ActionAnimationStarterAdapter(() =>
                    {
                        _crosshairAnimationsPlayer.PlayRecoil();    
                        _camRecoilPlayer.PlayRecoil();   
                        _gunRecoilPlayer.PlayRecoil();
                    }),
                    new AnimationCallbackAdapter(_crosshairAnimationsPlayer.OnRecoilFinished),
                    new GunslingerInputAdapter(() => Input.GetMouseButton(0), () => Input.GetKey(KeyCode.R))
                );
        }
        
        private void Update()
        {
            _gunslinger.Tick(Time.deltaTime);
        }
    }
}