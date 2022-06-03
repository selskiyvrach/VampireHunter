using Selskiyvrach.VampireHunter.Model.Animations;
using Selskiyvrach.VampireHunter.Model.Guns;
using Selskiyvrach.VampireHunter.Model.Stats;

namespace Selskiyvrach.VampireHunter.Model.Gunslingers
{
    public interface IGunslingerVisitor
    {
        void Visit(Eyes eyes, Arsenal arsenal, Accuracy accuracy, AnimationsPlayer animator, Gun gun);
    }
}