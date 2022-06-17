using Selskiyvrach.VampireHunter.Model.Guns;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Model.Arsenals
{
    [CreateAssetMenu(menuName = "Configs/Guns/Arsenal/ArsenalFactory", fileName = "ArsenalFactory", order = 0)]
    public class ArsenalFactory : ScriptableObject
    {
        [SerializeField] private GunConfig[] _gunConfigs;    
        
        public Arsenal Create() => 
            new Arsenal(_gunConfigs);
    }
}