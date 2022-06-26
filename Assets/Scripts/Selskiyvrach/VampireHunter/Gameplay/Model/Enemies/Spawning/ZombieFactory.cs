using Selskiyvrach.VampireHunter.Gameplay.Model.Creatures;
using UnityEngine;
using Zenject;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Enemies.Spawning
{
    public class ZombieFactory : MonoBehaviour, IFactory<ICreature>
    {
        [SerializeField] private ZombieInGameObjectContext _prefab;

        private DiContainer _container;

        [Inject]
        public void Construct(DiContainer container) => 
            _container = container;

        public ICreature Create() => 
            _container.InstantiatePrefab(_prefab).GetComponent<ZombieInGameObjectContext>().Item;
    }
}