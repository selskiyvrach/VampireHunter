using System;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Guns
{
    public readonly struct MagazineStatus
    {
        public int Bullets { get; }
        public int Capacity { get; }
        public bool Full => Bullets == Capacity;
        public bool Any => Bullets > 0;

        public MagazineStatus(int capacity) : this()
        {
            if(capacity <= 0)
                throw new ArgumentException("Capacity should be a positive number");
            Capacity = capacity;
        }

        public MagazineStatus(int capacity, int bullets) : this(capacity)
        {
            if(bullets < 0)
                throw new ArgumentException("Bullets cannot be a negative number");
            Bullets = bullets;
        }
    }
}