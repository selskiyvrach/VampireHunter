using Selskiyvrach.Core.Lifecycle;
using Selskiyvrach.Core.Tickers;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Enemies.Spawning
{
    public class EnemiesSpawner : LifecycleObject
    {
        private readonly ISpawningData _spawningData;
        private readonly Countdown _spawnCountdown;
        private int _spawnPositionIndex;

        public EnemiesSpawner(ISpawningData data)
        {
            _spawningData = data;
            _spawnCountdown = new Countdown(_spawningData.SpawnInterval, OnCountdownDown);
        }

        public override void Tick(float deltaTime)
        {
            base.Tick(deltaTime);
            _spawnCountdown.Tick(deltaTime);
        }

        private void OnCountdownDown()
        {
            SpawnEnemy();
            _spawnCountdown.Restart();
        }

        private void SpawnEnemy()
        {
            var spawnTransform = _spawningData.SpawnPositions[_spawnPositionIndex++ % _spawningData.SpawnPositions.Count];
            var creature = _spawningData.Factory.Create(spawnTransform.Position, spawnTransform.Rotation);
        }
    }
}