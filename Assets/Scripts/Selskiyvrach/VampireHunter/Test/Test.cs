using System.Threading.Tasks;
using Selskiyvrach.Core.StateMachines;
using Selskiyvrach.VampireHunter.Controller;
using Selskiyvrach.VampireHunter.Model.Guns;
using Selskiyvrach.VampireHunter.Model.Gunslingers;
using Selskiyvrach.VampireHunter.Unity;
using Selskiyvrach.VampireHunter.Unity.Animations;
using Selskiyvrach.VampireHunter.Unity.Cameras;
using Selskiyvrach.VampireHunter.Unity.Collisions;
using Selskiyvrach.VampireHunter.Unity.Combat;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Test
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private TestTriggerFactory _triggerFactory;
        [SerializeField] private Raycaster _raycaster;
        [SerializeField] private CrosshairAnimationsPlayer _crosshairAnimationsPlayer;
        [SerializeField] private RecoilAnimationPlayer _camRecoilPlayer;
        [SerializeField] private RecoilAnimationPlayer _gunRecoilPlayer;
        [SerializeField] private BulletFactory _bulletFactory;
        [SerializeField] private ScreenPointAsRay _screenPointAsRay;
        [SerializeField] private GunStats _stats;
        [SerializeField] private Barrel _barrel;
        [SerializeField] private AimingSettings _aimingSettings;
        [SerializeField] private CamFieldOfView _camFieldOfView;
        [SerializeField] private ScreenSizePixels _screenSize;
        [SerializeField] private CrosshairRadiusProvider _crosshairRadiusProvider;

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

            var sight = new Sight(
                new ScreenPointToRayAdapter(_screenPointAsRay),
                new ScreenSizeAdapter(_screenSize),
                new AimingSettingsAdapter(_aimingSettings),
                new RandomPointInUnitCircleGeneratorAdapter(),
                new CamFieldOfViewAdapter(_camFieldOfView),
                new GunStatsAdapter(_stats)
            );
            _crosshairRadiusProvider.CrosshairRadius = new CrosshairRadiusProviderAdapter(sight);
            _gun = new Gun(
                magazine, 
                sight,  
                _triggerFactory.Create(),
                new RaycasterAdapter(_raycaster), 
                new GunStatsAdapter(_stats), 
                new BarrelAdapter(_barrel),
                new AimingSettingsAdapter(_aimingSettings)
            );
            
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