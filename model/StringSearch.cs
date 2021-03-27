using System;
using System.Collections.Generic;

namespace Lab4.model
{
    class StringSearch
    {
        private readonly int mistakes = 3;

        private readonly String source;
        private readonly String find;
        private readonly int startIndex;

        private static volatile List<int> foundPos = new List<int>();

        public StringSearch(String source, String find, int startIndex)
        {
            this.source = source;
            this.find = find;
            this.startIndex = startIndex;
        }

        public void Search()
        {
            for (int sourceIterator = 0;
                sourceIterator <= source.Length - find.Length; sourceIterator++)
            {
                String s1 = source.Substring(sourceIterator, find.Length);
                String s2 = find;
                if (FindMistakes(s1, s2, mistakes))
                    lock (foundPos)
                        foundPos.Add(sourceIterator + startIndex);
            }
        }

        private bool FindMistakes(String s1, String s2, int mistakes)
        {
            int currentMistakes;
            if (s1.Length <= 2)
                currentMistakes = mistakes;
            else if (s1.Length <= 4)
                currentMistakes = mistakes - 1;
            else if (s1.Length <= 6)
                currentMistakes = mistakes - 2;
            else
                currentMistakes = 0;
            if (currentMistakes < 0)
                currentMistakes = 0;
            for (int i = 0; i < s1.Length; i++)
                if (s1[i] != s2[i])
                {
                    currentMistakes++;
                    if (currentMistakes > mistakes)
                        return false;
                }
            return true;
        }

        public static List<int> GetFoundPos()
        {
            lock (foundPos)
                return foundPos;
        }

        public static void ClearFoundPos()
        {
            lock (foundPos)
                foundPos.Clear();
        }
    }
}
