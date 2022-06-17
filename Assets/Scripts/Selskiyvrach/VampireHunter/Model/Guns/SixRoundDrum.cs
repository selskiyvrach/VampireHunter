using System;
using System.Collections.Generic;
using Selskiyvrach.VampireHunter.Model.Arsenals;

namespace Selskiyvrach.VampireHunter.Model.Guns
{
    public class SixRoundDrum : IMagazine
    {
        private readonly int _capacity;
        private readonly Queue<IBullet> _bullets = new Queue<IBullet>();
        
        public MagazineStatus Status => new MagazineStatus(_capacity, _bullets.Count);

        public SixRoundDrum(int capacity) => 
            _capacity = capacity;

        public IBullet PopBullet()
        {
            if(!Status.Any)
                throw new InvalidOperationException();
            return _bullets.Dequeue();
        }

        public void Load(Ammo ammo)
        {
            if (ammo.Count == 0)
                throw new InvalidOperationException();
            _bullets.Enqueue(ammo.Dequeue());
        }
    }
}