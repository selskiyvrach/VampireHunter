using Selskiyvrach.VampireHunter.Model.Animations;
using Selskiyvrach.VampireHunter.View;

namespace Selskiyvrach.VampireHunter.Controller
{
    public class AnimationStarterAdapter : IAnimationStarter
    {
        private readonly AnimationStarter _animationStarter;

        public AnimationStarterAdapter(AnimationStarter animationStarter)
        {
            _animationStarter = animationStarter;
        }

        public void StartAnimation()
        {
            _animationStarter.StartAnimation();   
        }
    }
}