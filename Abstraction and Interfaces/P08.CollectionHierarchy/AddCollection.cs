using System;
using System.Collections.Generic;
using System.Text;

namespace P08CollectionHierarchy
{
    public class AddCollection:IAddCollection
    {
        public AddCollection()
        {
            this.Data = new List<string>();
        }

        protected List<string> Data { get; private set; }
        public int Add(string item)
        {
            this.Data.Add(item);
            return this.Data.Count - 1;
        }
    }
}
