using System.Collections.Generic;
using System.Linq;
using Selskiyvrach.Core.DataStructures;

namespace Selskiyvrach.VampireHunter.Model.Stats
{
    public interface IStatProvider
    {
        public Stat GetStat<T>() where T : Stat;
    }

    public class StatProvider : IStatProvider
    {
        private readonly List<Stat> _stats = new List<Stat>();

        public void Add(Stat stat) => 
            _stats.Add(stat);

        public Stat GetStat<T>() where T : Stat => 
            _stats.FirstOrDefault(n => n is T) as T;
    }

    public abstract class Stat
    {
        public int Value { get; private set; }

        protected Stat()
        {
        }

        protected Stat(int value) => 
            Value = value;
    }

    public class Accuracy : Stat
    {
        public Accuracy(int value):base(value)
        {
        }
    }

    public class MagazineSize : Stat
    {
    }

    public class Damage : Stat
    {
        public Damage(int value) : base(value)
        {
        }
    }
}