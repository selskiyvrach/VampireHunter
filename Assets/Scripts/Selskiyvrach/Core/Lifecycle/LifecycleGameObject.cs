using System.Threading.Tasks;
using Selskiyvrach.Core.Tickers;
using UnityEngine;
using Zenject;
using ITickable = Selskiyvrach.Core.Tickers.ITickable;

namespace Selskiyvrach.Core.Lifecycle
{
    public abstract class LifecycleGameObject : MonoBehaviour, ITickable, IInitializable, IResourceReleaser, IEnablable
    {
        private LifecycleObject _lifecycleObject;

        [Inject]
        private void Construct(ITicker ticker)
        {
            _lifecycleObject = new LifecycleObject();
            _lifecycleObject.SetTicker(ticker);
        }

        public void Tick(float deltaTime) => 
            _lifecycleObject.Tick(deltaTime);

        public Task Initialize() => 
            _lifecycleObject.Initialize();

        public Task ReleaseResources() => 
            _lifecycleObject.ReleaseResources();

        public void Enable() => 
            _lifecycleObject.Enable();

        public void Disable() =>
            _lifecycleObject.Disable();
    }
}