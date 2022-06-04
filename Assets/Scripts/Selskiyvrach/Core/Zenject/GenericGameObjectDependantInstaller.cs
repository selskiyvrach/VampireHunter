using Selskiyvrach.Core.Unity.GameObjects;
using UnityEngine;
using Zenject;

namespace Selskiyvrach.Core.Zenject
{
    public abstract class GenericGameObjectDependantInstaller : MonoInstaller
    {
    }

    public class GenericGameObjectDependantInstaller<TDependant, TGameObject> : GenericGameObjectDependantInstaller
        where TGameObject : GameObjectMarker
    {
        [SerializeField]
        private TGameObject _gameObject;
        
        public override void InstallBindings()
        {
            Container.Bind<TDependant>().AsSingle();
            Container.Bind<TGameObject>().FromInstance(_gameObject);
        }
    }
}    
