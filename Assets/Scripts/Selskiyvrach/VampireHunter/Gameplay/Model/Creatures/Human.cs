using System;
using Selskiyvrach.Core.Tickers;
using Selskiyvrach.Core.Unity.Transforms;
using Selskiyvrach.VampireHunter.Gameplay.Model.BulletTargets;
using Selskiyvrach.VampireHunter.Gameplay.Model.Creatures.Limbs;
using Selskiyvrach.VampireHunter.Gameplay.Model.Healths;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Creatures
{
    public abstract class Human : ICreature
    {
        private readonly Head _head;
        private readonly Body _body;
        private readonly ITicker _ticker;
        private readonly Feet _feet;
        private Health _health;
        private DamageTakenNotifier _damageTakenNotifier;
        private OnDiedNotifier _onDiedNotifier;

        public ITransform Transform { get; }
        public int CurrentHealth => _health.CurrentHealth;
        public int MaxHealth => _health.MaxHealth;
        public bool Alive => _health.CurrentHealth > 0;
        
        public event Action OnDied
        {
            add => _onDiedNotifier.OnDied += value; 
            remove => _onDiedNotifier.OnDied -= value; 
        }

        public event Action OnHealthChanged
        {
            add => _health.OnHealthChanged += value;
            remove => _health.OnHealthChanged -= value;
        }

        public event Action<HitInfo> OnHeadHit
        {
            add => _head.OnHit += value; 
            remove => _head.OnHit -= value;
        }
        
        public event Action<HitInfo> OnBodyHit
        {
            add => _body.OnHit += value;
            remove => _body.OnHit -= value;
        }
        
        protected Human(Head head, Body body, HumanSettings settings, Transform transform, ITicker ticker)
        {
            CreateHealth(settings);
            _head = head;
            _body = body;
            _ticker = ticker;
            Transform = new TransformAdapter(transform);
            _feet = new Feet(Transform, settings.Speed);
            _ticker.AddTickable(_feet);
            head.Construct(_damageTakenNotifier, settings.HeadDamageCoeff);
            body.Construct(_damageTakenNotifier, settings.BodyDamageCoeff);
        }

        public void MoveTowards(Vector3 position) => 
            _feet.MoveTowards(position);

        private void CreateHealth(HumanSettings settings)
        {
            _health = new Health(settings.HealthSettings);
            _onDiedNotifier = new OnDiedNotifier(_health);
            _damageTakenNotifier = new DamageTakenNotifier(_onDiedNotifier);
            _damageTakenNotifier.OnDamageTaken += OnDamageReceived;
        }

        private void OnDamageReceived(int damage) =>
            Debug.Log($"Taken {damage} damage");

        public void LookAt(Vector3 pos)
        {
            var rotation = Quaternion.LookRotation(pos - Transform.Position, Vector3.up);
            Transform.Rotation = rotation;
        }
    }
}