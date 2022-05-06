using System;
using System.Collections.Generic;
using Sirenix.Utilities;

namespace Selskiyvrach.VampireHunter.Model.Guns
{
    public interface IMagazine : IMagazineData, IMagazineStatus, IReloadable
    {
        IBullet Pop();
    }
    
    public class Magazine : IMagazine
    {
        private readonly Stack<IBullet> _bullets = new Stack<IBullet>();
        public int Capacity { get; }
        public int CurrentLoad => _bullets.Count;
        public event Action<IntDelta> OnLoadChanged;

        public Magazine(int capacity)
        {
            Capacity = capacity;
        }

        public void Push(IBullet bullet)
        {
            if(CurrentLoad == Capacity)
                return;
            _bullets.Push(bullet);
            OnLoadChanged?.Invoke(new IntDelta(1));
        }

        public void Push(IEnumerable<IBullet> bullets)
        {
            var before = CurrentLoad;
            bullets.ForEach(n => _bullets.Push(n));
            OnLoadChanged?.Invoke(new IntDelta(CurrentLoad - before));
        }

        public IBullet Pop()
        {
            if(CurrentLoad < 1)
                throw new InvalidOperationException();
            var bullet = _bullets.Pop();
            OnLoadChanged?.Invoke(new IntDelta(-1));
            return bullet;
        }
    }
}