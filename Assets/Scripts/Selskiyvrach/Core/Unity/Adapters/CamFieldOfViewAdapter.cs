using Selskiyvrach.Core.Screen;
using Selskiyvrach.VampireHunter.Model.Crosshairs;
using Selskiyvrach.VampireHunter.Unity.Cameras;

namespace Selskiyvrach.Core.Unity.Adapters
{
    public class CamFieldOfViewAdapter : IVerticalFieldOfView
    {
        private readonly CamFieldOfView _camFieldOfView;

        public CamFieldOfViewAdapter(CamFieldOfView camFieldOfView) => 
            _camFieldOfView = camFieldOfView;

        public float FieldOfViewDegrees => _camFieldOfView.FieldOfView;
    }
}