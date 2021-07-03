using System;

namespace Sorting_Algorithms
{

    class Program
    {
        //Swap methods
        static void Swap(ref int valOne, ref int valTwo)
        {
            valOne = valOne + valTwo;
            valTwo = valOne - valTwo;
            valOne = valOne - valTwo;
        }

        static void SwapWithTemp(ref int valOne, ref int valTwo)
        {
            int temp = valOne;
            valOne = valTwo;
            valTwo = temp;
        }
        //BubbleSort
        static void BubbleSort(int[] inputArray)
        {
            for (int i = 0; i < inputArray.Length; i++)
            {
                for (int index = 0; index < inputArray.Length - 1; index++)
                {
                    if (inputArray[index] > inputArray[index + 1])
                    {
                        Swap(ref inputArray[index], ref inputArray[index + 1]);
                    }
                }
            }
        }
        //Method for creating an array
        static int[] Createrandomarr(int length)
        {
            Random rnd = new Random();
            int[] arr = new int[length];
            for (int i = 0; i < length; i++)
            {
                arr[i] = rnd.Next(0, 20);
            }
            return arr;

        }
        //Method to print array
        static void Printarr(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
        //QuickSort
        static void QuickSort(int[] inputArray)
        {
            int left = 0;
            int right = inputArray.Length - 1;
            InternalQuickSort(inputArray, left, right);
        }
        static void InternalQuickSort(int[] inputArray, int left, int right)
        {
            int pivotNewIndex = Partition(inputArray, left, right);
            int pivot = inputArray[(left + right) / 2];
            if (left < pivotNewIndex - 1)
                InternalQuickSort(inputArray, left, pivotNewIndex - 1);
            if (pivotNewIndex < right)
                InternalQuickSort(inputArray, pivotNewIndex, right);
        }
        static int Partition(int[] inputArray, int left, int right)
        {
            int i = left, j = right;
            int pivot = inputArray[(left + right) / 2];

            while (i <= j)
            {
                while (inputArray[i] < pivot)
                    i++;
                while (inputArray[j] > pivot)
                    j--;
                if (i <= j)
                {
                    SwapWithTemp(ref inputArray[i], ref inputArray[j]);
                    i++; j--;
                }
            }
            return i;
        }
        //SelectionSort
        static void SelectionSort(int[] inputArray)
        {
            int index_of_min = 0;
            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                index_of_min = i;
                for (int index = i + 1; index < inputArray.Length; index++)
                {
                    if (inputArray[index] < inputArray[index_of_min])
                        index_of_min = index;
                }
                SwapWithTemp(ref inputArray[i], ref inputArray[index_of_min]);
            }
        }
        //InsertionSort
        static void InsertionSort(int[] inputArray)
        {
            int j = 0;
            int temp = 0;
            for (int index = 1; index < inputArray.Length; index++)
            {
                j = index;
                temp = inputArray[index];
                while ((j > 0) && (inputArray[j - 1] > temp))
                {
                    inputArray[j] = inputArray[j - 1];
                    j = j - 1;
                }
                inputArray[j] = temp;
            }
        }
        //MergeSort
        static void MergeSort(int[] inputArray)
        {
            int left = 0;
            int right = inputArray.Length - 1;
            InternalMergeSort(inputArray, left, right);
        }
        static void InternalMergeSort(int[] inputArray, int left, int right)
        {
            int mid = 0;
            if (left < right)
            {
                mid = (left + right) / 2;
                InternalMergeSort(inputArray, left, mid);
                InternalMergeSort(inputArray, (mid + 1), right);
                MergeSortedArray(inputArray, left, mid, right);
            }
        }
        static void MergeSortedArray(int[] inputArray, int left, int mid, int right)
        {
            int index = 0;
            int total_elements = right - left + 1; 
            int right_start = mid + 1;
            int temp_location = left;
            int[] tempArray = new int[total_elements];

            while ((left <= mid) && right_start <= right)
            {
                if (inputArray[left] <= inputArray[right_start])
                {
                    tempArray[index++] = inputArray[left++];
                }
                else
                {
                    tempArray[index++] = inputArray[right_start++];
                }
            }
            if (left > mid)
            {
                for (int j = right_start; j <= right; j++)
                    tempArray[index++] = inputArray[right_start++];
            }
            else
            {
                for (int j = left; j <= mid; j++)
                    tempArray[index++] = inputArray[left++];
            }
            
            for (int i = 0, j = temp_location; i < total_elements; i++, j++)
            {
                inputArray[j] = tempArray[i];
            }
        }



        static void Main(string[] args)
        {
            Console.WriteLine("MergeSort");
            int[] arr=Createrandomarr(6);
            Printarr(arr);
            MergeSort( arr);
            Printarr(arr);
            Console.WriteLine("SelectionSort");
            int[] arr1 = Createrandomarr(7);
            Printarr(arr1);
            SelectionSort(arr1);
            Printarr(arr1);
            Console.WriteLine("InsertionSort");
            int[] arr2 = Createrandomarr(8);
            Printarr(arr2);
            InsertionSort(arr2);
            Printarr(arr2);
            Console.WriteLine("QuickSort");
            int[] arr3 = Createrandomarr(9);
            Printarr(arr3);
            QuickSort(arr3);
            Printarr(arr3);
            Console.WriteLine("BubbleSort");
            int[] arr4 = Createrandomarr(5);
            Printarr(arr4);
            BubbleSort(arr4);
            Printarr(arr4);




        }
    }
}
