using System;
using Selskiyvrach.Core.Factories;

namespace Selskiyvrach.VampireHunter.Model.Guns
{
    public interface IReloadable
    {
        void LoadBullet();
        void FullyLoad();
    }

    public interface IMagazineStatus
    {
        MagazineStatus Status { get; }
    }

    public interface IMagazine : IReloadable, IMagazineStatus
    {
        IBullet PopBullet();
    }
    
    public class Magazine : IMagazine
    {
        private readonly IFactory<IBullet> _bulletFactory;
        public MagazineStatus Status { get; private set; }
        
        public Magazine(IFactory<IBullet> bulletFactory) => 
            _bulletFactory = bulletFactory;

        public void LoadBullet()
        {
            if(Status.Full)
                throw new InvalidOperationException("Magazine is already full");
            Status = Status.OneBulletMore();
        }

        public void FullyLoad() =>
            Status = Status.FullyLoaded();

        public IBullet PopBullet()
        {
            if(!Status.Any)
                throw new InvalidOperationException();
            Status = Status.OneBulletLess();
            return _bulletFactory.Create();
        }
    }
}