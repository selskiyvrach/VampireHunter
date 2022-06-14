// using System;
// using System.Collections.Generic;
// using UnityEngine.Rendering;
//
// namespace Selskiyvrach.VampireHunter.Model.Stats
// {
//     public abstract class Stat
//     {
//         private readonly IStatValueProvider _valueProvider;
//
//         protected Stat(IStatValueProvider valueProvider) => 
//             _valueProvider = valueProvider;
//
//         public float GetValue()
//             => _valueProvider.GetValue();
//     }
//
//     public interface IStatValueProvider : IValueProvider
//     {
//     }
//
//     public interface IValueProvider
//     {
//         public event Action OnChanged;
//         public float GetValue();
//     }
//
//     public class OffOfContributorsStatValueProvider : IStatValueProvider
//     {
//         private readonly List<StatValueContributor> _contributors = new List<StatValueContributor>();
//
//         public event Action OnChanged;
//
//         public float GetValue()
//         {
//             var calculator = new ContributorsResultCalculator();
//             _contributors.ForEach(n => n.Accept(calculator));
//             return calculator.GetResult();
//         }
//     }
//
//     public abstract class StatValueContributor
//     {
//         public abstract void Accept(ContributorsResultCalculator calculator);
//     }
//     
//     public class BaseFlat : StatValueContributor
//     {
//         public BaseFlat(float value) : base(value)
//         {
//         }
//
//         public override void Accept(ContributorsResultCalculator calculator) =>
//             calculator.Visit(this);
//     }
//     
//     public class BonusFlat : StatValueContributor
//     {
//         public BonusFlat(float value) : base(value)
//         {
//         }
//
//         public override void Accept(ContributorsResultCalculator calculator) => 
//             calculator.Visit(this);
//     }
//     
//     public class BaseMultiplier : StatValueContributor
//     {
//         public BaseMultiplier(float value) : base(value)
//         {
//         }
//
//         public override void Accept(ContributorsResultCalculator calculator) => 
//             calculator.Visit(this);
//     }
//     
//     public class BonusMultiplier : StatValueContributor
//     {
//         public BonusMultiplier(float value) : base(value)
//         {
//         }
//
//         public override void Accept(ContributorsResultCalculator calculator) => 
//             calculator.Visit(this);
//     }
//
//     public class ContributorsResultCalculator
//     {
//         public float GetResult()
//         {
//         }
//
//         public void Reset()
//         {
//         }
//
//         public void Visit(BonusFlat baseFlat)
//         {
//         }
//
//         public void Visit(BaseFlat baseFlat)
//         {
//         }
//
//         public void Visit(BaseMultiplier baseMultiplier)
//         {
//         }
//
//         public void Visit(BonusMultiplier baseMultiplier)
//         {
//         }
//     }
//
//     public abstract class StatEffectType
//     {
//         
//     }
// }