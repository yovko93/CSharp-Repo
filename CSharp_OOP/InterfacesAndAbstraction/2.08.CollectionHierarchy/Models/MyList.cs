using System.Linq;
using System.Collections.Generic;

using _2._08.CollectionHierarchy.Contracts;

namespace _2._08.CollectionHierarchy.Models
{
    public class MyList<T> : AddRemoveCollection<T>, IMyList<T>
    {
        private const int RemovalIndex = 0;


        public IReadOnlyCollection<T> Used
        {
            get
            {
                return this.Data as IReadOnlyCollection<T>;
            }
        }

        public override T Remove()
        {
            var firstElement = this.Data.First();
            this.Data.RemoveAt(RemovalIndex);
            return firstElement;
        }
    }
}
