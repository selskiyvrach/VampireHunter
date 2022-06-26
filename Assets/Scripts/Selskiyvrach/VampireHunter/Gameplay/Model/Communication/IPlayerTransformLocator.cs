using Selskiyvrach.Core.Unity.Transforms;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Communication
{
    public interface IPlayerTransformLocator
    {
        ITransform PlayerTransform { get; }
    }
}