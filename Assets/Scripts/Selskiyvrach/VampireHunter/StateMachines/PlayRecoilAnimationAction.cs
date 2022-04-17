using Selskiyvrach.Core.StateMachines;

namespace Selskiyvrach.VampireHunter.StateMachines
{
    public class PlayRecoilAnimationAction : IAction
    {
        private readonly RecoilAnimationPlayer _recoilAnimationPlayer;

        public PlayRecoilAnimationAction(RecoilAnimationPlayer recoilAnimationPlayer)
        {
            _recoilAnimationPlayer = recoilAnimationPlayer;
        }

        public void Act()
        {
            _recoilAnimationPlayer.PlayRecoilAnimation();
        }
    }
}