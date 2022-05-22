using Selskiyvrach.Core;
using Selskiyvrach.VampireHunter.Model.SceneLoading;

namespace Selskiyvrach.VampireHunter.Model
{
    public class Game 
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly ITicker _ticker;
        
        public Game(ISceneLoader sceneLoader, ITicker ticker)
        {
            _sceneLoader = sceneLoader;
            _ticker = ticker;
            _sceneLoader.LoadScene(SceneIDs.Gameplay);
        }    
    }
}