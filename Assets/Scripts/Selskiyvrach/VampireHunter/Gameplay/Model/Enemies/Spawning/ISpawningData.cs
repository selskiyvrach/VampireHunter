using System.Collections.Generic;
using Selskiyvrach.VampireHunter.Gameplay.Model.Creatures;
using UnityEngine;
using Zenject;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Enemies.Spawning
{
    public interface ISpawningData
    {
        public int ConcurrentEnemies { get; }
        public IFactory<ICreature> Factory { get; }
        public IReadOnlyList<Vector3> SpawnPositions { get; }
        public float SpawnInterval { get; }
    }
}