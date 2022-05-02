using System;

namespace Selskiyvrach.VampireHunter.Model.Gunslingers
{
    public interface IGunslingerInput
    {
        bool ProceedShootingSequence();
        bool Reload();
    }
    
    public class GunslingerInputAdapter : IGunslingerInput
    {
        private readonly Func<bool> _proceedShootingInput;
        private readonly Func<bool> _reload;

        public GunslingerInputAdapter(Func<bool> proceedShootingInput, Func<bool> reload)
        {
            _proceedShootingInput = proceedShootingInput;
            _reload = reload;
        }

        public bool ProceedShootingSequence() =>
            _proceedShootingInput.Invoke();

        public bool Reload() =>
            _reload.Invoke();
    }
}