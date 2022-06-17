using System.Collections.Generic;
using JetBrains.Annotations;
using Selskiyvrach.VampireHunter.Model.Guns;

namespace Selskiyvrach.VampireHunter.Model.Arsenals
{
    public class Ammo : Queue<IBullet>
    {
        public Ammo([NotNull] IEnumerable<IBullet> collection) : base(collection)
        {
        }
    }
}