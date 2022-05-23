using System;

namespace Selskiyvrach.Core.StateMachines
{
    public interface IState : IDisposable
    {
        void Enter(StateMachine stateMachine);
    }
}