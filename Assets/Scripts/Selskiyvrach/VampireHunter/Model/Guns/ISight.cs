using Selskiyvrach.Core.Math;

namespace Selskiyvrach.VampireHunter.Model.Guns
{
    public interface IPointer
    {
        Ray GetPointingRay();
    }
    
    public interface ISight : IPointer
    {
        Ray GetShotProjection();
    }

    public class Sight : ISight
    {
        private readonly IPointer _pointer;

        public Sight(IPointer pointer) =>
            _pointer = pointer;

        public Ray GetPointingRay() =>
            _pointer.GetPointingRay();

        public Ray GetShotProjection() =>
            new Ray();
    }
}
