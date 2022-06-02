using System;
using Selskiyvrach.Core;
using Selskiyvrach.Core.StateMachines;
using Selskiyvrach.VampireHunter.Model.Animations;
using Selskiyvrach.VampireHunter.Model.Guns;

namespace Selskiyvrach.VampireHunter.Model.Gunslingers
{
    public interface IGunslinger
    {
    }

    public class Gunslinger : ITickable, IDisposable, IGunslinger
    {
        public void Tick(float deltaTime)
        {
        }

        public void Dispose()
        {
        }
    }
}