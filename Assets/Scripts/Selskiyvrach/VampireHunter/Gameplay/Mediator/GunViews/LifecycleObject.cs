using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Selskiyvrach.Core.Tickers;
using Zenject;
using ITickable = Selskiyvrach.Core.Tickers.ITickable;

namespace Selskiyvrach.VampireHunter.Gameplay.Mediator.GunViews
{
    public abstract class LifecycleObject : ITickable
    {
        private readonly HashSet<IDisposable> _disposables = new HashSet<IDisposable>();
        private ITicker _ticker;

        [Inject]
        private void SetTicker(ITicker ticker)
        {
            if (tickIsOverridden())
                _ticker = ticker;

            bool tickIsOverridden() =>
                GetType().GetTypeInfo().DeclaredMethods.Any(n => n.Name == nameof(Tick));
        }

        public virtual Task Initialize() =>
            Task.CompletedTask;

        public virtual void Enable() => 
            _ticker?.AddTickable(this);

        public virtual void Disable()
        {
            foreach (var disposable in _disposables)
                disposable.Dispose();
            _disposables.Clear();
            
            _ticker?.RemoveTickable(this);
        }

        public virtual void Tick(float deltaTime) { }

        public virtual Task ReleaseResources() =>
            Task.CompletedTask;

        protected void StageForDisableWithThis(IDisposable disposable) => 
            _disposables.Add(disposable);

        protected bool RemoveDisposable(IDisposable disposable) => 
            _disposables.Remove(disposable);
    }
}