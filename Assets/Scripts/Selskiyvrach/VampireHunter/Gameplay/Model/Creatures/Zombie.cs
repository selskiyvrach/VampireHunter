using Selskiyvrach.Core.Tickers;
using Selskiyvrach.VampireHunter.Gameplay.Model.Creatures.Limbs;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Creatures
{
    public class Zombie : Human
    {
        public Zombie(Head head, Body body, HumanSettings settings, Transform transform, ITicker ticker) : base(head, body, settings, transform, ticker)
        {
        }
    }
}