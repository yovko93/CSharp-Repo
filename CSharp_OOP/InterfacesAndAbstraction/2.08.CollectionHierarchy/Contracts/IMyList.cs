using System.Collections.Generic;

namespace _2._08.CollectionHierarchy.Contracts
{
    public interface IMyList<T> : IAddRemoveCollection<T>
    {
        IReadOnlyCollection<T> Used { get; }
    }
}
