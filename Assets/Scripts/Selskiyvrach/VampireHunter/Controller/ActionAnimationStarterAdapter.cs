using System;
using Selskiyvrach.VampireHunter.Model.Animations;

namespace Selskiyvrach.VampireHunter.Controller
{
    public class ActionAnimationStarterAdapter : IAnimationStarter
    {
        private readonly Action _animationStarter;

        public ActionAnimationStarterAdapter(Action animationStarter)
        {
            _animationStarter = animationStarter;
        }

        public void StartAnimation()
        {
            _animationStarter.Invoke();            
        }
    }
}