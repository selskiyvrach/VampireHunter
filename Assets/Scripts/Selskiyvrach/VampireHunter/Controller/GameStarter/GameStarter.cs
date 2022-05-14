using Selskiyvrach.VampireHunter.Model;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Controller.GameStarter
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] private GameUpdater _gameUpdater;
        
        private Game _game;
        
        private void Start()
        {
            // _game = new Game();
            // _gameUpdater.Construct(_game);
        }
    }
}