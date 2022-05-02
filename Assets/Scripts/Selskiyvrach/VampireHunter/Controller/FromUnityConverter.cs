using Selskiyvrach.Core.Math;

namespace Selskiyvrach.VampireHunter.Controller
{
    public static class FromUnityConverter
    {
        public static Ray FromUnityToProject(this UnityEngine.Ray source)
        {
            return new Ray(source.origin.FromUnityToProject(), source.direction.FromUnityToProject());
        }

        public static Vector3 FromUnityToProject(this UnityEngine.Vector3 source)
        {
            return new Vector3(source.x, source.y, source.z);
        }
    }
}