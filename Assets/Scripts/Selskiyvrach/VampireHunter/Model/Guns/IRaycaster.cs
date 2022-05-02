using Selskiyvrach.Core.Math;

namespace Selskiyvrach.VampireHunter.Model.Guns
{
    public interface IRaycaster
    {
        bool Raycast(Ray ray);
    }
}