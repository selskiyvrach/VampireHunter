using Selskiyvrach.Core.Math;

namespace Selskiyvrach.VampireHunter.Controller
{
    public static class UnityProjectConverterExtensions
    {
        public static Ray ToProject(this UnityEngine.Ray source)
        {
            return new Ray(source.origin.ToProject(), source.direction.ToProject());
        }
        
        public static UnityEngine.Ray ToUnity(this Ray source)
        {
            return new UnityEngine.Ray(source.StartPos.ToUnity(), source.Direction.ToUnity());
        }

        public static Vector3 ToProject(this UnityEngine.Vector3 source)
        {
            return new Vector3(source.x, source.y, source.z);
        }
        
        public static UnityEngine.Vector3 ToUnity(this Vector3 source)
        {
            return new UnityEngine.Vector3(source.X, source.Y, source.Z);
        }
    }
}