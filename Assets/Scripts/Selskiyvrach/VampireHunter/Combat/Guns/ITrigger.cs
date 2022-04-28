namespace Selskiyvrach.VampireHunter.Combat.Guns
{
    public interface ITrigger
    {
        bool IsCocked { get; }
        void Cock();
        void Pull();
    }
    
    public class SimpleTrigger : ITrigger
    {
        public bool IsCocked { get; private set; } = true;
        
        public void Cock()
        {
            IsCocked = true;
        }

        public void Pull()
        {
            IsCocked = false;
        }
    }
}