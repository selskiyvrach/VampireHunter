using System.Collections.Generic;
using Selskiyvrach.VampireHunter.Model.Guns;

namespace Selskiyvrach.VampireHunter.Model.Gunslingers
{
    public class Arsenal
    {
        private readonly List<Gun> _guns = new List<Gun>();

        public int Count => _guns.Count;
        public bool Any => Count > 0;

        public Gun GetGun(int index) => 
            _guns[index];
    }
}