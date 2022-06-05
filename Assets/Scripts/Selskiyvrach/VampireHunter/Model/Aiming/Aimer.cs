using UnityEngine;

namespace Selskiyvrach.VampireHunter.Model.Aiming
{
    public class Aimer
    {
        public Vector3 AimDirection { get; private set; }
        
        public void AdjustAimDirection(Vector2 delta) => 
            AimDirection += (Vector3)delta;
    }
}