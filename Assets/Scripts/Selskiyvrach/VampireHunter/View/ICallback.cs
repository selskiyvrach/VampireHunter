using System;

namespace Selskiyvrach.VampireHunter.View
{
    public interface ICallback
    {
        event Action OnInvoked;
    }
}