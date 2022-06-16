using UnityEngine;

namespace Selskiyvrach.VampireHunter.Model.Guns
{
    [CreateAssetMenu(menuName = "Configs/Guns/GunDefinition", fileName = "GunDefinition", order = 0)]
    public class GunDefinition : ScriptableObject
    {
        [SerializeField] private string _name;
        public string Name => _name;
    }
}    