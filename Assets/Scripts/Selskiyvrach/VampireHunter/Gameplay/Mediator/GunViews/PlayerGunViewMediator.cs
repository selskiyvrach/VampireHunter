using ModestTree.Util;
using Selskiyvrach.Core.Tickers;
using Selskiyvrach.VampireHunter.Gameplay.Model.Players;
using Selskiyvrach.VampireHunter.Gameplay.View.GunViews;
using UnityEngine;
using ITickable = Selskiyvrach.Core.Tickers.ITickable;

namespace Selskiyvrach.VampireHunter.Gameplay.Mediator.GunViews
{
    public class PlayerGunViewMediator : ITickable
    {
        private readonly GunViewsFactory _gunViewsFactory;
        private readonly ITicker _ticker;
        private readonly Player _player;
        
        private GameObject _currentlyDisplayed;
        private int _currentlyDisplayedID;
        
        public PlayerGunViewMediator(Player player, GunViewsFactory gunViewsFactory, ITicker ticker)
        {
            _player = player;
            _gunViewsFactory = gunViewsFactory;
            _ticker = ticker;
            _ticker.AddTickable(this);
        }

        public void Tick(float deltaTime)
        {
            if (_player.Gun.ConfigID == _currentlyDisplayedID)
                return;

            Object.Destroy(_currentlyDisplayed);
            _currentlyDisplayedID = _player.Gun.ConfigID;
            _currentlyDisplayed = _gunViewsFactory.Create(_currentlyDisplayedID);
            _currentlyDisplayed.transform.SetParent(_player.Gun.Transform, false);
        }
    }
}