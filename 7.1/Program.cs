using System;

class Program
{
    static void Main(string[] args)
    {
        int[] list1 = { 1, 2, 3, 4, 5 };
        int[] list2 = { 6, 7, 8, 9, 10 };

        bool areListsDistinct = AreListsDistinct(list1, list2);

        if (areListsDistinct)
            Console.WriteLine("Списки не содержат одинаковых элементов");
        else
            Console.WriteLine("Списки содержат одинаковые элементы");
    }

    static bool AreListsDistinct(int[] list1, int[] list2)
    {
        for (int i = 0; i < list1.Length; i++)
        {
            for (int j = 0; j < list2.Length; j++)
            {
                if (list1[i] == list2[j])
                    return false;
            }
        }
        return true;
    }
}
