using System;

namespace Selskiyvrach.VampireHunter.Model.Guns
{
    public interface IMagazine : IMagazineData, IMagazineStatus, IReloadable
    {
        IBullet Pop();
    }
    
    public class Magazine : IMagazine
    {
        private readonly IBulletProvider _bulletProvider;

        public int Capacity { get; }
        public int CurrentLoad { get; private set; }
        public event Action<IntDelta> OnLoadChanged;

        public Magazine(IBulletProvider bulletProvider, int capacity)
        {
            _bulletProvider = bulletProvider;
            CurrentLoad = Capacity = capacity;
        }

        public void LoadOne()
        {
            if(CurrentLoad == Capacity)
                return;
            CurrentLoad++;
            OnLoadChanged?.Invoke(new IntDelta(1));
        }

        public void LoadFull()
        {
            var before = CurrentLoad;
            CurrentLoad = Capacity;
            OnLoadChanged?.Invoke(new IntDelta(CurrentLoad - before));
        }

        public IBullet Pop()
        {
            if(CurrentLoad < 1)
                throw new InvalidOperationException();
            
            CurrentLoad--;
            OnLoadChanged?.Invoke(new IntDelta(-1));
            return _bulletProvider.GetBullet();
        }
    }

    public interface IBulletProvider
    {
        public IBullet GetBullet();
    }
}