using System;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Model.Guns
{
    public interface IMagazine : IMagazineData, IMagazineStatus, IReloadable
    {
        IBullet Pop();
    }
    
    public class SimpleMagazine : IMagazine
    {
        private readonly IBulletProvider _bulletProvider;

        public int Capacity { get; }
        public int CurrentLoad { get; private set; } 

        public SimpleMagazine(IBulletProvider bulletProvider, int capacity)
        {
            _bulletProvider = bulletProvider;
            CurrentLoad = Capacity = capacity;
        }

        public void LoadOne()
        {
            if(CurrentLoad < Capacity)
                CurrentLoad++;
        }

        public void LoadFull()
        {
            CurrentLoad = Capacity;
        }

        public IBullet Pop()
        {
            if(CurrentLoad < 1)
                throw new InvalidOperationException();
            
            CurrentLoad--;
            Debug.Log("bullets left: " + CurrentLoad);
            return _bulletProvider.GetBullet();
        }
    }

    public interface IBulletProvider
    {
        public IBullet GetBullet();
    }
}