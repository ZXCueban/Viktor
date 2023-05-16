using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> list1 = new List<int> { 1, 2, 3, 4, 5 };
        List<int> list2 = new List<int> { 1, 7, 8 };
        bool containsElements = CheckLists(list1, list2);
        if (containsElements)
        {
            Console.WriteLine("Первый список содержит элементы из второго списка.");
        }
        else
        {
            Console.WriteLine("Первый список не содержит элементы из второго списка.");
        }
    }

    static bool CheckLists<T>(List<T> list1, List<T> list2)
    {
        foreach (var element in list2)
        {
            if (list1.Contains(element))
            {
                return true; 
            }
        }
        return false; 
    }
}
