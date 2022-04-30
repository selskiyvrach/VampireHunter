using System;

namespace Selskiyvrach.VampireHunter.Model.Animations
{
    public interface IAnimationCallback
    {
        event Action OnInvoked;
    }
}