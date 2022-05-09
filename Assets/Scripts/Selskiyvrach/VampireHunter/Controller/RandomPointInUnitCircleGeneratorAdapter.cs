using Selskiyvrach.VampireHunter.Model.Guns;
using UnityEngine;
using Vector2 = Selskiyvrach.Core.Maths.Vector2;

namespace Selskiyvrach.VampireHunter.Controller
{
    public class RandomPointInUnitCircleGeneratorAdapter : IRandomPointInUnitCircleGenerator
    {
        public Vector2 GetPoint => Random.insideUnitCircle.ToProject();
    }
}