using System;
using System.Collections.Generic;
using System.Text;

namespace P08CollectionHierarchy
{
    interface IMyList:IAddCollection,IAddRemoveCollection
    {
        int Used { get; }
    }
}
