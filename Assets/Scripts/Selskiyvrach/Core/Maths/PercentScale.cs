namespace Selskiyvrach.Core.Maths
{
    public class PercentScale
    {
        protected const int MAX = 100;
        public int Value { get; set; }
        public float Normalized => Value / MAX;
    }
}