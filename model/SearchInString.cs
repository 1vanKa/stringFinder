using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab4
{
    class SearchInString
    {
        private int insertCost = 1;
        private int deleteCost = 1;
        private int replaceCost = 1;

        private String source;
        private String find;
        private int mistakes;

        private List<int> foundPos;

        public SearchInString(String source, String find, int mistakes)
        {
            this.source = source;
            this.find = find;
            this.mistakes = mistakes;
            foundPos = new List<int>();
            search();
            //Task[] tasks = new Task[source.Length / 1000];
            //for (int i = 0; i < source.Length; i += 1000)
            //{
            //    tasks[i] = new Task(() => search(source.Substring(i, 1000)));
            //    tasks[i].Start();
            //}
        }

        private void search()
        {
            for (int sourceIterator = 0;
                sourceIterator <= source.Length - find.Length; sourceIterator++)
            {
                String s1 = source.Substring(sourceIterator, find.Length);
                String s2 = find;
                if (mistakes >= levensteinInstruction(s1, s2, insertCost, deleteCost, replaceCost))
                    foundPos.Add(sourceIterator);
            }
        }

        private int levensteinInstruction(String s1, String s2, int insertCost, int deleteCost, int replaceCost)
        {
            int[,] d = new int[s1.Length + 1, s2.Length + 1];
            d[0, 0] = 0;
            for (int j = 1; j <= s2.Length; j++)
                d[0, j] = d[0, j - 1] + insertCost;
            for (int i = 1; i <= s1.Length; i++)
            {
                d[i, 0] = d[i - 1, 0] + deleteCost;
                for (int j = 1; j <= s2.Length; j++)
                    if (s1[i - 1] != s2[j - 1])
                        d[i, j] = min(
                            d[i - 1, j] + deleteCost,
                            d[i, j - 1] + insertCost,
                            d[i - 1, j - 1] + replaceCost);
                    else
                        d[i, j] = d[i - 1, j - 1];
            }
            return d[s1.Length, s2.Length];
        }

        private int min(int i1, int i2, int i3)
        {
            return Math.Min(Math.Min(i1, i2), i3);
        }

        public List<int> getFoundPos()
        {
            return foundPos;
        }

        public String getSourceString()
        {
            return source;
        }

        public String getFindString()
        {
            return find;
        }

        public int getMistakes()
        {
            return mistakes;
        }
    }
}
