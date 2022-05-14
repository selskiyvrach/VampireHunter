using TMPro;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Unity.UI
{
    public class MagazineStatusPanel : Displayable
    {
        [SerializeField] private TMP_Text _currentLoadText;
        [SerializeField] private TMP_Text _capacityText;

        private MagazineStatusInfo _lastInfo;

        public void UpdateValues(MagazineStatusInfo info)
        {
            if (info.Capacity != _lastInfo.Capacity)
                _capacityText.text = info.Capacity.ToString();
            if (info.CurrentLoad != _lastInfo.CurrentLoad)
                _currentLoadText.text = info.CurrentLoad.ToString();
            
            _lastInfo = info;
        }

        public override void Show() =>
            gameObject.SetActive(true);

        public override void Hide() =>
            gameObject.SetActive(false);
    }

    public readonly struct MagazineStatusInfo
    {
        public readonly int Capacity;
        public readonly int CurrentLoad;

        public MagazineStatusInfo(int capacity, int currentLoad)
        {
            Capacity = capacity;
            CurrentLoad = currentLoad;
        }
    }
}