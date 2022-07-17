using System.Threading.Tasks;
using UnityEngine;

namespace Selskiyvrach.Core.Lifecycle
{
    public abstract class LifecycleGameObject : MonoBehaviour
    {
        public Task Initialize() => 
            Task.CompletedTask;

        public void Enable()
        {
        }

        public void Disable()
        {
        }

        public Task ReleaseResources() => 
            Task.CompletedTask;
    }
}