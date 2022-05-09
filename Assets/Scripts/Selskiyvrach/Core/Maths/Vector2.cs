namespace Selskiyvrach.Core.Maths
{
    public readonly struct Vector2
    {
        public readonly float X;
        public readonly float Y;

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public static Vector2 operator +(Vector2 a, Vector2 b) =>
            new Vector2(a.X + b.X, a.Y + b.Y);
        
        public static Vector2 operator -(Vector2 a, Vector2 b) =>
            new Vector2(a.X - b.X, a.Y - b.Y);
        
        public static Vector2 operator *(Vector2 a, Vector2 b) =>
            new Vector2(a.X * b.X, a.Y * b.Y);
        
        public static Vector2 operator /(Vector2 a, Vector2 b) =>
            new Vector2(a.X / b.X, a.Y / b.Y);
        
        public static Vector2 operator /(Vector2 a, float b) =>
            new Vector2(a.X / b, a.Y / b);
        
        public static Vector2 operator *(Vector2 a, float b) =>
            new Vector2(a.X * b, a.Y * b);
    }
}