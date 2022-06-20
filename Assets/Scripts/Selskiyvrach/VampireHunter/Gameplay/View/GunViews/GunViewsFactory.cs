using System;
using System.Linq;
using Selskiyvrach.VampireHunter.Gameplay.Model.Guns;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.View.GunViews
{
    [CreateAssetMenu(menuName = "Configs/Guns/GunViewsFactory", fileName = "gun_views_factory", order = 0)]
    public class GunViewsFactory : ScriptableObject
    {
        [SerializeField] private GunObjectForConfig[] _views;
        
        public GameObject Create(int configID)
        {
            var prefab = _views.First(n => n.GunConfig.ConfigID == configID).Prefab;
            return Instantiate(prefab);
        }

        [Serializable]
        private class GunObjectForConfig
        {
            [SerializeField] private GunConfig _gunConfig;
            [SerializeField] private GameObject _prefab;

            public GunConfig GunConfig => _gunConfig;
            public GameObject Prefab => _prefab;
        }
    }
}