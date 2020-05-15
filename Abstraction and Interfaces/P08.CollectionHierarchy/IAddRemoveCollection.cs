using System;
using System.Collections.Generic;
using System.Text;

namespace P08CollectionHierarchy
{
    public interface IAddRemoveCollection:IAddCollection
    {
        
        string Remove();
    }
}
