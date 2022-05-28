using Selskiyvrach.VampireHunter.Controller;
using Selskiyvrach.VampireHunter.Model.Crosshairs;
using UnityEngine;
using Vector2 = Selskiyvrach.Core.Maths.Vector2;

namespace Selskiyvrach.Core.Unity.Adapters
{
    public class RandomPointInUnitCircleGeneratorAdapter : IRandomPointInUnitCircleGenerator
    {
        public Vector2 GetPoint => Random.insideUnitCircle.ToProject();
    }
}