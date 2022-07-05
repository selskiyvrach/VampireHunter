using System.Collections.Generic;
using Selskiyvrach.Core.Tickers;
using Selskiyvrach.VampireHunter.Gameplay.Model.Communication;
using UnityEngine;
using ITickable = Selskiyvrach.Core.Tickers.ITickable;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Enemies.Spawning
{
    public class EnemiesSpawner : ITickable
    {
        private readonly ISpawningData _spawningData;
        private readonly ITicker _ticker;
        private readonly IPlayerTransformLocator _playerLocator;
        private readonly Countdown _spawnCountdown;
        private readonly List<EnemyBrain> _enemies = new List<EnemyBrain>();
        private int _spawnPositionIndex;

        public EnemiesSpawner(ISpawningData data, ITicker ticker, IPlayerTransformLocator playerLocator)
        {
            _spawningData = data;
            _ticker = ticker;
            _playerLocator = playerLocator;
            _ticker.AddTickable(this);
            _spawnCountdown = new Countdown(_spawningData.SpawnInterval, OnCountdownDown);
        }

        public void Tick(float deltaTime) => 
            _spawnCountdown.Tick(deltaTime);

        private void OnCountdownDown()
        {
            SpawnEnemy();
            _spawnCountdown.Restart();
        }

        private void SpawnEnemy()
        {
            if (_enemies.Count == _spawningData.ConcurrentEnemies)
                return;
            var pos =_spawningData.SpawnPositions[_spawnPositionIndex++ % _spawningData.SpawnPositions.Count];
            var creature = _spawningData.Factory.Create(pos, Quaternion.LookRotation(_playerLocator.PlayerTransform.Position));
            var brain = new EnemyBrain(creature, _playerLocator);
            _enemies.Add(brain);
        }
    }
}