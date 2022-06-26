using Selskiyvrach.VampireHunter.Gameplay.Model.Communication;
using Selskiyvrach.VampireHunter.Gameplay.Model.Creatures;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Enemies
{
    public class EnemyBrain
    {
        private readonly ICreature _creature;
        private readonly IPlayerTransformLocator _playerLocator;

        public EnemyBrain(ICreature creature, IPlayerTransformLocator playerLocator)
        {
            _creature = creature;
            _playerLocator = playerLocator;
            _creature.LookAt(_playerLocator.PlayerTransform.Position);
            _creature.MoveTowards(_playerLocator.PlayerTransform.Position);
        }
    }
}