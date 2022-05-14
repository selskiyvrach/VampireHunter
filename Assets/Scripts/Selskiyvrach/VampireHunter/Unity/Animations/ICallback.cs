using System;

namespace Selskiyvrach.VampireHunter.Unity.Animations
{
    public interface ICallback
    {
        event Action OnInvoked;
    }
}