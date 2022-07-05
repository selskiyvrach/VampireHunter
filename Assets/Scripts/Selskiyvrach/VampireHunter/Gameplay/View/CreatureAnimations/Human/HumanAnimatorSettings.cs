using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.View.CreatureAnimations.Human
{
    [CreateAssetMenu(menuName = "Configs/Animation/Human/HumanAnimatorSettings", fileName = "human_animator_settings", order = 0)]
    public class HumanAnimatorSettings : ScriptableObject, IHumanAnimatorSettings
    {
        [SerializeField] private string[] _headHitTriggerNames;
        [SerializeField] private string[] _bodyHitTriggerNames;
        [SerializeField] private string[] _deathTriggerNames;
        
        private int[] _headHitHashes;
        private int[] _bodyHitHashes;
        private int[] _deathHashes;

        [Button]
        public void Update()
        {
            _headHitHashes = _headHitTriggerNames.Select(Animator.StringToHash).ToArray(); 
            _bodyHitHashes = _bodyHitTriggerNames.Select(Animator.StringToHash).ToArray(); 
            _deathHashes = _deathTriggerNames.Select(Animator.StringToHash).ToArray(); 
        }
        
        public IReadOnlyList<int> HeadHitHashes => _headHitHashes;
        public IReadOnlyList<int> BodyHitHashes => _bodyHitHashes;
        public IReadOnlyList<int> DeathHashes => _deathHashes;
    }
}