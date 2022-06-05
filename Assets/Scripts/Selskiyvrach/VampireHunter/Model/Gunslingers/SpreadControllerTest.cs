using Selskiyvrach.Core.Unity.Tickers;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Model.Gunslingers
{
    public class SpreadControllerTest : MonoBehaviour
    {
        [SerializeField] private AnimationCurve _kickCurve;
        [SerializeField] private TickerRunner _tickerRunner;
        private SpreadController _spreadController;
        
        private void Start()
        {
            _spreadController = new SpreadController(_tickerRunner, _kickCurve);
            Debug.Log(_spreadController.Spread);
        }

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