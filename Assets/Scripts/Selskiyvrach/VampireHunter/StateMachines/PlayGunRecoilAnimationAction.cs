using Selskiyvrach.Core.StateMachines;

namespace Selskiyvrach.VampireHunter.StateMachines
{
    public class PlayGunRecoilAnimationAction : IAction
    {
        private readonly GunAnimationsPlayer _gunAnimationsPlayer;

        public PlayGunRecoilAnimationAction(GunAnimationsPlayer gunAnimationsPlayer)
        {
            _gunAnimationsPlayer = gunAnimationsPlayer;
        }

        public void Act()
        {
            _gunAnimationsPlayer.PlayRecoilAnimation();
        }
    }
}