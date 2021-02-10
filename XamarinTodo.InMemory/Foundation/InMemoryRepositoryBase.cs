using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinTodo.InMemory.Foundation
{
    public abstract class InMemoryRepositoryBase<TKey, TValue>
    {
        public Dictionary<TKey, TValue> Db { get; } = new Dictionary<TKey, TValue>();

        public virtual void Save(TValue value)
        {
            var id = GetKey(value);
            Db[id] = DeepClone(value);
        }

        public virtual TValue Find(TKey key)
        {
            var result = Db.TryGetValue(key, out var value);
            if (result)
            {
                var instance = DeepClone(value);
                return instance;
            }
            else
            {
                return default(TValue);
            }
        }

        public virtual void Update(TValue value)
        {
            var id = GetKey(value);
            Db[id] = DeepClone(value);
        }

        public virtual void Delete(TKey key)
        {
            Db.Remove(key);
        }

        protected abstract TKey GetKey(TValue value);
        protected abstract TValue DeepClone(TValue value);
    }
}