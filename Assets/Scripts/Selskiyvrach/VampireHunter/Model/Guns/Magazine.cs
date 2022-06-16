using System;
using System.Collections.Generic;
using Selskiyvrach.Core.Factories;

namespace Selskiyvrach.VampireHunter.Model.Guns
{
    public class Magazine : IMagazine
    {
        private readonly int _capacity;
        private readonly Queue<IBullet> _bullets = new Queue<IBullet>();
        
        public MagazineStatus Status => new MagazineStatus(_capacity, _bullets.Count);

        public Magazine(int capacity) => 
            _capacity = capacity;

        public void LoadBullet(IBullet bullet)
        {
            if(Status.Full)
                throw new InvalidOperationException("Magazine is already full");
            _bullets.Enqueue(bullet);
        }

        public IBullet PopBullet()
        {
            if(!Status.Any)
                throw new InvalidOperationException();
            return _bullets.Dequeue();
        }
    }
}