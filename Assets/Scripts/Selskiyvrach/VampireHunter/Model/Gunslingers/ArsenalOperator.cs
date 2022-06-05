using System.Collections.Generic;
using Selskiyvrach.VampireHunter.Model.Guns;

namespace Selskiyvrach.VampireHunter.Model.Gunslingers
{
    public class ArsenalOperator
    {
        private readonly Arsenal _arsenal = new Arsenal();

        public IReadOnlyList<Gun> Guns => _arsenal.Guns;
        public Gun CurrentGun { get; private set; }

        public void ChangeGun(int index) =>
            CurrentGun = _arsenal.GetGun(index);
    }
}