using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Selskiyvrach.Core.Tickers;
using Zenject;
using ITickable = Selskiyvrach.Core.Tickers.ITickable;

namespace Selskiyvrach.Core.Lifecycle
{
    public class LifecycleObject : ITickable, IInitializable, IResourceReleaser, IEnablable
    {
        private readonly HashSet<IDisposable> _disposables = new HashSet<IDisposable>();
        private readonly HashSet<IInitializable> _initializables = new HashSet<IInitializable>();
        private readonly HashSet<IResourceReleaser> _resourceReleasers = new HashSet<IResourceReleaser>();
        private readonly HashSet<IEnablable> _enablables = new HashSet<IEnablable>();
        private ITicker _ticker;

        [Inject]
        public void SetTicker(ITicker ticker) => 
            _ticker = ticker;

        public virtual Task Initialize() => 
            Task.WhenAll(_initializables.Select(n => n.Initialize()));

        public virtual void Enable()
        {
            _ticker.AddTickable(this);
            foreach (var child in _enablables)
                child.Enable();
        }

        public virtual void Disable()
        {
            foreach (var disposable in _disposables)
                disposable.Dispose();

            foreach (var child in _enablables)
                child.Disable();
            
            _ticker.RemoveTickable(this);
        }

        public virtual void Tick(float deltaTime) {}

        public virtual Task ReleaseResources() => 
            Task.WhenAll(_resourceReleasers.Select(n => n.ReleaseResources()));

        protected void AddLifecycleChild(object child)
        {
            if (child == this)
                throw new InvalidOperationException("Cannot add self as a child");

            if (child is IEnablable enablable)
                _enablables.Add(enablable);
            
            if (child is IInitializable initializable)
                _initializables.Add(initializable);
            
            if (child is IResourceReleaser resourceReleaser)
                _resourceReleasers.Add(resourceReleaser);
        }

        protected void AddTickable(ITickable tickable) => 
            _ticker.AddTickable(tickable);

        protected void RemoveTickable(ITickable tickable) => 
            _ticker.RemoveTickable(tickable);

        protected void DisposeOnDisable(IDisposable disposable) => 
            _disposables.Add(disposable);
    }
}