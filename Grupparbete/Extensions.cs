using System;
using System.Collections.Generic;
using System.Text;

namespace Grupparbete
{
    static class Extensions
    {
        public static void Print<T>(this IEnumerable<T> collectionToPrint)
        {
            Print(collectionToPrint, a => a.ToString());
        }

        public static void Print<T>(this IEnumerable<T> collectionToPrint, Func<T, string> convertItemToString)
        {
            foreach (var item in collectionToPrint)
            {
                Console.WriteLine(convertItemToString(item));
            }
        }

        public static void SortGenericArray<T>(this List<T> anyArr, Func<T, T, bool> lessThan)
        {
            for (int i = 0; i < anyArr.Count - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < anyArr.Count; j++)
                    if (lessThan(anyArr[j], anyArr[minIndex]))
                        minIndex = j;
                T tmp = anyArr[i];
                anyArr[i] = anyArr[minIndex];
                anyArr[minIndex] = tmp;
            }
        }
    }
}
