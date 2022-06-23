using Selskiyvrach.Core.Tickers;
using Selskiyvrach.VampireHunter.Gameplay.Model.Guns;
using Selskiyvrach.VampireHunter.Gameplay.Model.Guns.Settings;
using Selskiyvrach.VampireHunter.Gameplay.Model.Spreads;
using UnityEngine;
using Zenject;
using ITickable = Selskiyvrach.Core.Tickers.ITickable;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Gunslingers
{
    public class Hand : MonoBehaviour, ITickable
    {
        [SerializeField] private Transform _gunHolder;
        [SerializeField] private Transform _recoilPerformer;
        [SerializeField] private float _recoilIntensityCoefficient = 5;
        
        private RecoilProcessorComposite _recoilProcessor;
        private ITicker _ticker;

        [Inject]
        public void Construct(ITicker ticker, IHandRecoilProcessingSettings recoilProcessingSettings)
        {
            _recoilProcessor = new RecoilProcessorComposite(recoilProcessingSettings);
            _ticker = ticker;
            ticker.AddTickable(this);
        }

        public void Tick(float deltaTime)
        {
            _recoilProcessor.Tick(deltaTime);
            var rotationX = _recoilProcessor.Value * _recoilIntensityCoefficient;
            _recoilPerformer.localRotation = Quaternion.Euler(-rotationX, 0, 0);
        }

        public void Kick(float recoilAmount) => 
            _recoilProcessor.Kick(recoilAmount);

        public void SetGun(Gun gun) =>
            gun.Transform.SetParent(_gunHolder, false);
    }
}