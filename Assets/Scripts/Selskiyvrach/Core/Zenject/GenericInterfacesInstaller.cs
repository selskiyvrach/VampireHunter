using UnityEngine;
using Zenject;

namespace Selskiyvrach.Core.Zenject
{
    public class GenericInterfacesInstaller<T> : MonoInstaller where T : MonoBehaviour
    {
        [SerializeField] private T _component;
        
        public override void InstallBindings() => 
            Container.BindInterfacesTo<T>().FromInstance(_component);
    }
}