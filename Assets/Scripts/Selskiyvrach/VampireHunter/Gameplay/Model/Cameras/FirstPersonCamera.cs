using Selskiyvrach.VampireHunter.Gameplay.Model.Gunslingers;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Cameras
{
    public class FirstPersonCamera
    {
        public FirstPersonCamera(Gunslinger gunslinger, Camera camera) => 
            gunslinger.Eyes.SetCamera(camera);
    }
}