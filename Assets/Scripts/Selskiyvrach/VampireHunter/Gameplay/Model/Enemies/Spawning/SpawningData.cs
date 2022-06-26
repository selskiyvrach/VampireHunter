using System.Collections.Generic;
using System.Linq;
using Selskiyvrach.VampireHunter.Gameplay.Model.Creatures;
using UnityEngine;
using Zenject;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Enemies.Spawning
{
    public class SpawningData : MonoBehaviour, ISpawningData
    {
        [SerializeField] private ZombieFactory _factory;
        [SerializeField] private float _spawnInterval;
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private int _concurrentEnemies;
        
        private List<Vector3> _spawnPositions;

        public int ConcurrentEnemies => _concurrentEnemies;
        public IFactory<ICreature> Factory => _factory;
        public IReadOnlyList<Vector3> SpawnPositions => _spawnPositions ??= _spawnPoints.Select(n => n.position).ToList();
        public float SpawnInterval => _spawnInterval;
    }
}