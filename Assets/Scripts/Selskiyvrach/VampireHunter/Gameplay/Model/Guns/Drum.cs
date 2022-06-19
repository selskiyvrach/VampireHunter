using System;
using System.Collections.Generic;
using Selskiyvrach.VampireHunter.Gameplay.Model.Arsenals;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Guns
{
    public class Drum : IMagazine
    {
        private readonly int _capacity;
        private readonly Queue<IBullet> _bullets = new Queue<IBullet>();
        
        public MagazineStatus Status => new MagazineStatus(_capacity, _bullets.Count);

        public Drum(int capacity) => 
            _capacity = capacity; 

        public IBullet PopBullet()
        {
            if(!Status.Any)
                throw new InvalidOperationException();
            return _bullets.Dequeue();
        }

        public void Reload(Ammo ammo)
        {
            if (ammo.Count == 0)
                throw new InvalidOperationException();
            _bullets.Enqueue(ammo.Dequeue());
        }

        public void Refill(Ammo ammo)
        {
            while (_bullets.Count < _capacity && ammo.Count > 0)
                _bullets.Enqueue(ammo.Dequeue());
        }
    }
}