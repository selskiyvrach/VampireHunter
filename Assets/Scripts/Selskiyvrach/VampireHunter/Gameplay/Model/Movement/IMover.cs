using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Movement
{
    public interface IMover
    {
        Vector3 Destination { get; set; }
        Vector3 Velocity { get; }
        float Speed { get; set; }
        float StoppingDistance { get; set; }
    }

    public interface IMoverSettings
    {
        float Speed { get; }  
        float StoppingDistance {get;}   
    }
}