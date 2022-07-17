using System.Collections.Generic;
using Selskiyvrach.Core.Unity.Transforms;
using Selskiyvrach.VampireHunter.Gameplay.Model.Creatures;
using UnityEngine;
using Zenject;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Enemies.Spawning
{
    public interface ISpawningData
    {
        public int ConcurrentEnemies { get; }
        public IFactory<Vector3, Quaternion, Creature> Factory { get; }
        public IReadOnlyList<ITransform> SpawnPositions { get; }
        public float SpawnInterval { get; }
    }
}