using SortAlgorithms.HelperClasses;
using System.Xml.Linq;
using System;

namespace SortAlgorithmsLibrary
{
    public class InsertionSorts : SortAlgorithms
    {
        public static void InsertionSort(int[] arr)
        {
            int n = arr.Length;

            for (int i = 1; i < n; i++)
            {
                int temp = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > temp)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = temp;
            }
        }

        public static void ShellSort(int[] arr)
        {
            int n = arr.Length;
            int gap = n / 2;

            while (gap > 0)
            {
                for (int i = gap; i < n; i++)
                {
                    int temp = arr[i];
                    int j = i;

                    while (j >= gap && arr[j - gap] > temp)
                    {
                        arr[j] = arr[j - gap];
                        j -= gap;
                    }
                    arr[j] = temp;
                }
                gap /= 2;
            }
        }

        public static void SplaySort(int[] arr)
        {
            SplayTree tree = new SplayTree();
            Node? root = null;

            for (int i = 0; i < arr.Length; i++)
            {
                root = tree.Insert(root, arr[i]);
            }
            int index = 0;

            tree.InOrderTraversal(root, (key) =>
            {
                arr[index++] = key;
            });
        }
    }
}
