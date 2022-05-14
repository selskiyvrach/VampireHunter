using Selskiyvrach.VampireHunter.Model;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Controller.GameStarter
{
    public class GameUpdater : MonoBehaviour
    {
        private Game _game;

        public void Construct(Game game) => 
            _game = game;

        private void Update() => 
            _game?.Tick(Time.deltaTime);
    }
}