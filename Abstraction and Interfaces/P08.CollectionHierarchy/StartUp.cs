using System;
using System.Linq;
using System.Text;

namespace P08CollectionHierarchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();
            StringBuilder sb = new StringBuilder();
            var input = Console.ReadLine().Split();
            FillCollection(ref input, addCollection,sb);
            FillCollection(ref input, addRemoveCollection,sb);
            FillCollection(ref input, myList,sb);

            var numberOfRemovals = int.Parse(Console.ReadLine());
            RemoveOperation(numberOfRemovals, addRemoveCollection,sb);
            RemoveOperation(numberOfRemovals, myList,sb);

            Console.WriteLine(sb.ToString().Trim());



        }
        private static void RemoveOperation(int numberOfRemovals, IAddRemoveCollection collection,StringBuilder sb)
        {
            while (numberOfRemovals > 0)
            {
                var removedElement = collection.Remove();
                sb.Append($"{removedElement} ");
                numberOfRemovals--;
            }

            sb
                .Remove(sb.Length - 1, 1)
                .AppendLine();
        }
        private static void FillCollection(ref string[] input, IAddCollection collection,StringBuilder sb)
        {
            foreach (var str in input)
            {
                var index = collection.Add(str);
                sb.Append($"{index} ");
            }

            sb
                .Remove(sb.Length - 1, 1)
                .AppendLine();
        }
    }
}
