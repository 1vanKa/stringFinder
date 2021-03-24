using Lab4.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.controller
{
    class StringSearchController
    {
        private static readonly int charAmount = 1000;
        public static List<int> search(String source, String find)
        {
            Task[] tasks = new Task[source.Length / charAmount];
            for (int i = 0; i < source.Length; i += charAmount)
            {
                String subSource = source.Substring(i, charAmount + find.Length - 1);
                tasks[i] = new Task(() => new StringSearch(subSource, find, i));
                tasks[i].Start();
            }
            Task.WaitAll();
            return StringSearch.getFoundPos();
        }
    }
}
