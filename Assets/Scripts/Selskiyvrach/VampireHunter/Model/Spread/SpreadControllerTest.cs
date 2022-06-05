using UnityEngine;
using Zenject;

namespace Selskiyvrach.VampireHunter.Model.Spread
{
    public class SpreadControllerTest : MonoBehaviour
    {
        private SpreadCalculator _spreadCalculator;
        
        [Inject]
        public void Construct(SpreadCalculatorFactory spreadCalculatorFactory) => 
            _spreadCalculator = spreadCalculatorFactory.Create();

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                _spreadCalculator.StartAiming();
            if(Input.GetMouseButtonUp(0))
                _spreadCalculator.StopAiming();
            
            if(Input.GetMouseButtonDown(1))
                _spreadCalculator.Kick(100);
            
            Debug.Log(_spreadCalculator.Spread);
        }
    }
}