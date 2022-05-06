using System.Collections.Generic;

namespace Selskiyvrach.VampireHunter.Model.Guns
{
    public interface IReloadable
    {
        void Push(IBullet bullet);
        void Push(IEnumerable<IBullet> bullets);
    }
}