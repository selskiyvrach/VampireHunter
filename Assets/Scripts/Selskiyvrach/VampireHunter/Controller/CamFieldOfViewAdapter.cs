using Selskiyvrach.VampireHunter.Model.Guns;
using Selskiyvrach.VampireHunter.Unity.Cameras;

namespace Selskiyvrach.VampireHunter.Controller
{
    public class CamFieldOfViewAdapter : IVerticalFieldOfView
    {
        private readonly CamFieldOfView _camFieldOfView;

        public CamFieldOfViewAdapter(CamFieldOfView camFieldOfView)
        {
            _camFieldOfView = camFieldOfView;
        }

        public float FieldOfViewDegrees => _camFieldOfView.FieldOfView;
    }
}