namespace Selskiyvrach.Core.Maths
{
    public readonly struct Ray
    {
        public readonly Vector3 StartPos;
        public readonly Vector3 Direction;

        public Ray(Vector3 startPos, Vector3 direction)
        {
            StartPos = startPos;
            Direction = direction;
        }
    }
}