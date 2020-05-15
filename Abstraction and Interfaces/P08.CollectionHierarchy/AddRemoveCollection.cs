using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P08CollectionHierarchy
{
    public class AddRemoveCollection : IAddRemoveCollection
    {
        public AddRemoveCollection()
        {
            this.Data = new List<string>();
        }
        protected List<string> Data { get; private set; }
        public int Add(string item)
        {
            this.Data.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            string el = this.Data.Last();
            this.Data.Remove(el);
            return el;
        }
    }
}
