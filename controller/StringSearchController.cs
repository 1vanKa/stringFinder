using Lab4.model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab4.controller
{
    class StringSearchController
    {
        private static readonly int charAmount = 1000;
        private static Task[] tasks;

        public static List<int> Search(String source, String find)
        {
            if (tasks != null)
            {
                Task.WaitAll(tasks);
                tasks = null;
            }
            StringSearch.ClearFoundPos();
            tasks = new Task[source.Length / charAmount + 1];
            for (int i = 0; i * charAmount < source.Length; i++)
            {
                int length;
                if (i * charAmount + charAmount + find.Length - 1 >= source.Length)
                    length = source.Length - i * charAmount;
                else length = charAmount + find.Length - 1;
                String subSource = source.Substring(i * charAmount, length);
                int currentI = i;
                tasks[i] = new Task(() => new StringSearch(subSource, find, currentI * charAmount).Search());
                tasks[i].Start();
            }
            Task.WaitAll(tasks);
            return StringSearch.GetFoundPos();
        }
    }
}
