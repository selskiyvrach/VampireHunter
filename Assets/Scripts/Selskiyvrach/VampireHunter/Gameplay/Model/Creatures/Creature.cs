using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Creatures
{
    public abstract class Creature : ISpaceOrientable
    {
        protected abstract IMover Mover { get; }
        protected abstract ILooker Looker { get; }

        public void MoveTowards(Vector3 position) => 
            Mover.MoveTowards(position);

        public void LookAt(Vector3 point) =>
            Looker.LookAt(point);
    }
}