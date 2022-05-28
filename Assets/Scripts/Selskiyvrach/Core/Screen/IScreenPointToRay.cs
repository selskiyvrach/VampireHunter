using Selskiyvrach.Core.Maths;

namespace Selskiyvrach.Core.Screen
{
    public interface IScreenPointToRay
    {
        Ray GetRayFromNormalizedPos(Vector2 screenPosNorm);
    }
}