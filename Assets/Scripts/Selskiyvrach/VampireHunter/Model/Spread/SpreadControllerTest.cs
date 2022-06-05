using UnityEngine;
using Zenject;

namespace Selskiyvrach.VampireHunter.Model.Spread
{
    public class SpreadControllerTest : MonoBehaviour
    {
        private SpreadController _spreadController;
        
        [Inject]
        public void Construct(SpreadControllerFactory spreadControllerFactory) => 
            _spreadController = spreadControllerFactory.Create();

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                _spreadController.StartAiming();
            if(Input.GetMouseButtonUp(0))
                _spreadController.StopAiming();
            
            if(Input.GetMouseButtonDown(1))
                _spreadController.Kick(100);
            
            Debug.Log(_spreadController.Spread);
        }
    }
}