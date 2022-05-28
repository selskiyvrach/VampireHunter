using System;
using System.Collections.Generic;
using System.Linq;

namespace Selskiyvrach.Core.DataStructures
{
    public class TypeToObjectDictionary<TBase> where TBase : class
    {
        private Dictionary<Type, TBase> _elements = new Dictionary<Type, TBase>();
                    
        public TConcrete GetElement<TConcrete>() where TConcrete : class, TBase
        {
            if (_elements.TryGetValue(typeof(TConcrete), out TBase instance))
                return instance as TConcrete;
            return null;
        }

        public void Add(IEnumerable<TBase> elements) => 
            _elements = elements.ToDictionary(n => n.GetType(), n => n);
    }
}