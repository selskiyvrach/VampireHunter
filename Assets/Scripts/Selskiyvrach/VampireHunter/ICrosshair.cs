namespace Selskiyvrach.VampireHunter
{
    public interface ICrosshair
    {
        bool Idled { get; }
        bool Aimed { get; }
        void TransitionToRecoil();
        void TransitionToIdle();
        void TransitionToAimed();
    }
}