using System.Linq;

using _2._08.CollectionHierarchy.Contracts;

namespace _2._08.CollectionHierarchy.Models
{
    public class AddRemoveCollection<T> : AddCollection<T>, IAddRemoveCollection<T>
    {
        private const int IndexForAddinItem = 0;

        public override int Add(T item)
        {
            this.Data.Insert(IndexForAddinItem, item);
            return IndexForAddinItem;
        }

        public virtual T Remove()
        {
            var lastItem = this.Data.Last();
            this.Data.RemoveAt(this.Data.Count - 1);
            return lastItem;
        }
    }
}
