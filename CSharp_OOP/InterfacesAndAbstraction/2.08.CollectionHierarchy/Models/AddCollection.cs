using System.Collections.Generic;

using _2._08.CollectionHierarchy.Contracts;

namespace _2._08.CollectionHierarchy.Models
{
    public class AddCollection<T> : IAddCollection<T>
    {
        public AddCollection()
        {
            this.Data = new List<T>();
        }

        protected List<T> Data { get; set; }

        public virtual int Add(T item)
        {
            this.Data.Add(item);
            return this.Data.Count - 1;
        }
    }
}
