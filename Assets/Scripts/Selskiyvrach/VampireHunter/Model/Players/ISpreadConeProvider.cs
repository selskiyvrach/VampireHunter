using Selskiyvrach.Core.Maths;

namespace Selskiyvrach.VampireHunter.Model.Players
{
    public interface ISpreadConeProvider
    {
        Cone SpreadCone { get; }
    }
}