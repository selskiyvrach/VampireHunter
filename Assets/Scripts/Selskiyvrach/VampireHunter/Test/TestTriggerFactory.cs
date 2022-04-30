using Selskiyvrach.VampireHunter.Controller;
using Selskiyvrach.VampireHunter.Model.Guns;
using Selskiyvrach.VampireHunter.View;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Test
{
    public class TestTriggerFactory : MonoBehaviour
    {
        [SerializeField] private AnimationStarter _animationStarter;
        [SerializeField] private AnimationCallbackReceiver _animationCallback;
        
        public ITrigger Create()
        {
            return new Trigger(
                new AnimationStarterAdapter(_animationStarter), 
                new AnimationCallbackAdapter(_animationCallback));
        }
    }
}