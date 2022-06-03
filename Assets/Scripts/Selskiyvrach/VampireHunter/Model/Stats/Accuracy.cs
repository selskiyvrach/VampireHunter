namespace Selskiyvrach.VampireHunter.Model.Stats
{
    public class Accuracy : Stat 
    {
        public Accuracy(int value) : base(value)
        {
        }
    }

    public abstract class Stat
    {
        public int Value { get; }

        public Stat(int value) => 
            Value = value;
    }
}