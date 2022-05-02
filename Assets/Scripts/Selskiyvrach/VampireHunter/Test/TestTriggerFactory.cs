using Selskiyvrach.VampireHunter.Controller;
using Selskiyvrach.VampireHunter.Model.Guns;
using Selskiyvrach.VampireHunter.View;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Test
{
    public class TestTriggerFactory : MonoBehaviour
    {
        [SerializeField] private AnimationStarter _cockAnimationStarter;
        [SerializeField] private AnimationCallbackReceiver _cockAnimationCallback;
        [SerializeField] private AnimationStarter _shootAnimationStarter;
        [SerializeField] private AnimationCallbackReceiver _shootAnimationCallback;
        
        public ITrigger Create()
        {
            return new Trigger(
                new AnimationStarterAdapter(_cockAnimationStarter), 
                new AnimationCallbackAdapter(_cockAnimationCallback),
                new AnimationStarterAdapter(_shootAnimationStarter), 
                new AnimationCallbackAdapter(_shootAnimationCallback));
        }
    }
}