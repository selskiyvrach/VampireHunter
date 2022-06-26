using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Creatures
{
    public interface IMover
    {
        void MoveTowards(Vector3 position);
    }
}