using System.Collections.Generic;
using JetBrains.Annotations;
using Selskiyvrach.VampireHunter.Gameplay.Model.Bullets;
using Selskiyvrach.VampireHunter.Gameplay.Model.Guns;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Arsenals
{
    public class Ammo : Queue<IBullet>
    {
        public Ammo([NotNull] IEnumerable<IBullet> collection) : base(collection)
        {
        }
    }
}