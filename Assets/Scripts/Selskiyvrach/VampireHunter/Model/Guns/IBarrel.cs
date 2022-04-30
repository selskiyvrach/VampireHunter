using Selskiyvrach.Core.Math;

namespace Selskiyvrach.VampireHunter.Model.Guns
{
    public interface IBarrel
    {
        Vector3 ShootPoint { get; }
    }

    public class SimpleBarrel : IBarrel
    {
        private readonly IPointProvider _pointProvider;

        public Vector3 ShootPoint => _pointProvider.GetPoint();

        public SimpleBarrel(IPointProvider pointProvider)
        {
            _pointProvider = pointProvider;
        }
    }

    public interface IPointProvider
    {
        Vector3 GetPoint();
    }
}