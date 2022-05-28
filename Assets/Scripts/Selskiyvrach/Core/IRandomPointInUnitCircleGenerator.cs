using Selskiyvrach.Core.Maths;

namespace Selskiyvrach.Core
{
    public interface IRandomPointInUnitCircleGenerator
    {
        Vector2 GetPoint { get; }
    }
}