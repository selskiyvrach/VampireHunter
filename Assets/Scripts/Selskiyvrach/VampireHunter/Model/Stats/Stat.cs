using System.Collections.Generic;

namespace Selskiyvrach.VampireHunter.Model.Stats
{
    public class ModifiersBasedStat : IStat
    {
        private static readonly ModifiersCalculatorVisitor _calculatorVisitor = new ModifiersCalculatorVisitor();
        private readonly List<StatModifier> _statModifiers = new List<StatModifier>();
        private float _value;
        private bool _isDirty;

        public float GetValue()
        {
            if (_isDirty) 
                _value = GetCalculatedValue();
            return _value;
        }

        public void AddModifier(StatModifier modifier)
        {
            _statModifiers.Add(modifier);
            _isDirty = true;
        }

        public bool RemoveModifier(StatModifier modifier)
        {
            if (!_statModifiers.Remove(modifier))
                return false;
            return _isDirty = true;
        }

        private float GetCalculatedValue()
        {
            _calculatorVisitor.Reset();
            for (var i = 0; i < _statModifiers.Count; i++)
                _statModifiers[i].Accept(_calculatorVisitor);
            return _calculatorVisitor.GetResult();
        }
    }
    
    public class ModifiersCalculatorVisitor
    {
        private float _baseFlat = 0;
        private float _bonusFlat = 0;
        private float _baseMultiplier = 1;
        private float _bonusMultiplier = 1;
        private float _totalMultiplier = 1;

        public void AddBaseTerm(float value) =>
            _baseFlat += value;
        
        public void AddBonusTerm(float value) =>
            _bonusFlat += value;

        public void AddBaseMultiplier(float value) => 
            _baseMultiplier *= value;

        public void AddBonusMultiplier(float value) => 
            _bonusMultiplier *= value;

        public void AddTotalMultiplier(float value) => 
            _totalMultiplier *= value;

        public float GetResult()
        {
            var baseTotal = _baseFlat * _baseMultiplier;
            var bonusTotal = _bonusFlat * _bonusMultiplier;
            var total = (baseTotal + bonusTotal) * _totalMultiplier;
            return total;
        }

        public void Reset()
        {
            _baseFlat = 0;
            _bonusFlat = 0;
            _baseMultiplier = 1;
            _bonusMultiplier = 1;
            _totalMultiplier = 1;
        }
    }

    public interface IStat
    {
        public float GetValue();
    }

    public class StatModifier
    {
        public void Accept(ModifiersCalculatorVisitor calculatorVisitor)
        {
            
        }
    }
}