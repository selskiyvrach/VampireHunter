namespace Selskiyvrach.VampireHunter.Model.Guns
{
    public interface ITrigger
    {
        bool IsCocked { get; }
        void Cock();
        void Pull();
    }
    
    public class Trigger : ITrigger
    {
        public bool IsCocked { get; private set; } = true;

        public void Cock() => 
            IsCocked = true;

        public void Pull() => 
            IsCocked = false;
    }
}