using Selskiyvrach.VampireHunter.Controller;
using Selskiyvrach.VampireHunter.Model.Crosshairs;
using Selskiyvrach.VampireHunter.Model.Guns;
using Selskiyvrach.VampireHunter.Model.Gunslingers;
using Selskiyvrach.VampireHunter.Model.Stats;
using Selskiyvrach.VampireHunter.Unity;
using Selskiyvrach.VampireHunter.Unity.Animations;
using Selskiyvrach.VampireHunter.Unity.Cameras;
using Selskiyvrach.VampireHunter.Unity.Collisions;
using Selskiyvrach.VampireHunter.Unity.Combat;
using UnityEngine;
using Barrel = Selskiyvrach.VampireHunter.Unity.Combat.Barrel;

namespace Selskiyvrach.VampireHunter.Test
{
    public class Test : MonoBehaviour
    {
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

        private void Update()
        {
            // _gunslinger.Tick(Time.deltaTime);
        }
    }
}