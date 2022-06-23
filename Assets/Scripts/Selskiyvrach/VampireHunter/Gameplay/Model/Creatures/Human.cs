using Selskiyvrach.VampireHunter.Gameplay.Model.Creatures.Limbs;
using Selskiyvrach.VampireHunter.Gameplay.Model.Healths;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Creatures
{
    public class Human: Creature
    {
        private Head _head;
        private Body _body;
        private Health _health;
        private DamageTakenNotifier _damageTakenNotifier;

        public Human(Head head, Body body, HumanSettings settings)
        {
            CreateHealth(settings);
            _head = head;
            _body = body;
            head.Construct(_damageTakenNotifier, settings.HeadDamageCoeff);
            body.Construct(_damageTakenNotifier, settings.BodyDamageCoeff);
        }

        private void CreateHealth(HumanSettings settings)
        {
            _health = new Health(settings.HealthSettings);
            _damageTakenNotifier = new DamageTakenNotifier(_health);
            _damageTakenNotifier.OnDamageTaken += OnDamageReceived;
        }

        private void OnDamageReceived(int damage) => 
            Debug.Log($"Taken {damage} damage");
    }
}