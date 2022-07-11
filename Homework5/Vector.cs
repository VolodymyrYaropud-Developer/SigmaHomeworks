using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5
{
    internal class Vector
    {
        int[] arr;
        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < arr.Length)
                {
                    return arr[index];
                }
                else
                {
                    throw new Exception("Index out of range array");
                }
            }
            set
            {
                arr[index] = value;
            }
        }

        public Vector(int[] arr)
        {
            this.arr = arr;
        }

        public Vector(int n)
        {
            arr = new int[n];
        }

        public Vector() { }

        public void RandomInitialization(int a, int b)
        {
            Random random = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(a, b);
            }
        }

        public Pair[] CalculateFreq()
        {

            Pair[] pairs = new Pair[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                pairs[i] = new Pair(0, 0);

            }
            int countDifference = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                bool isElement = false;
                for (int j = 0; j < countDifference; j++)
                {
                    if (arr[i] == pairs[j].Number)
                    {
                        pairs[j].Freq++;
                        isElement = true;
                        break;
                    }
                }
                if (!isElement)
                {
                    pairs[countDifference].Freq++;
                    pairs[countDifference].Number = arr[i];
                    countDifference++;
                }
            }

            Pair[] result = new Pair[countDifference];
            for (int i = 0; i < countDifference; i++)
            {
                result[i] = pairs[i];
            }

            return result;
        }
        #region Homework
        public void IsPalindrome()
        {
            string str = string.Join("", arr);
            string tempStr = string.Join("", arr.Reverse());

            var test = string.Equals(tempStr, str);
            Console.WriteLine($"{str} is {(test ? "Palindrome" : "no Palindrome")}");
        }

        public int[] ReverseArray()
        {
            int[] res = new int[arr.Length];
            for (int i = arr.Length - 1, count = 0; i >= 0; count++, i--)
            {
                res[i] = arr[count];
            }

            return res;
        }

        public void TheLargestSequence()
        {
            int count = 1;
            int logestNum = arr[0];
            int logestCount = 1;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] != arr[i - 1])
                {
                    count = 0;
                }
                count++;
                if (count > logestCount)
                {
                    logestCount = count;
                    logestNum = arr[i];
                }

            }
            Console.WriteLine(string.Join(" ", Enumerable.Repeat(logestNum, logestCount)));
        }

        public void InitShafle()
        {
            Random rand = new Random();
            int x;
            while (true)
            {
                int index = Array.IndexOf(arr, 0);
                if (index == -1)
                    break;
                for (int i = 0; i < arr.Length;)
                {
                    x = rand.Next(1, arr.Length + 1);
                    if (!arr.Contains(x))
                    {
                        arr[i] = x;
                        i++;
                    }
                }

            }
        }


        public void Quick_Sort(Vector vs, int left, int right)
        {

            if (left < right)
            {
                int pivot = Partition(vs, left, right);

                if (pivot > 1)
                {
                    Quick_Sort(vs, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    Quick_Sort(vs, pivot + 1, right);
                }
            }
            int Partition(Vector vs, int left, int right)
            {
                int pivot = arr[left];
                while (true)
                {

                    while (arr[left] < pivot)
                    {
                        left++;
                    }

                    while (arr[right] > pivot)
                    {
                        right--;
                    }

                    if (left < right)
                    {
                        if (arr[left] == arr[right]) return right;

                        int temp = arr[left];
                        arr[left] = arr[right];
                        arr[right] = temp;
                    }
                    else
                    {
                        return right;
                    }
                }
            }
        }

        public int lenght()
        {
            return arr.Length;
        }

        public  void AddToFile(string path)
        {

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                fs.Close();
                using (StreamWriter sw = new StreamWriter(path))
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        sw.Write(arr[i]+" ");
                    }                    
                }
            }

        }
        public  void ReadFromFile(string path)
        {
            using (StreamReader sr = new StreamReader (path))
            {
                var temp = sr.ReadLine().Split(" ");
                arr = new int[temp.Length-1]; 
                for (int i = 0; i < arr.Length; i++)
                {
                   arr[i] =  int.Parse(temp[i]);
                }
            }
        }


        public int[] SortArrayOfMerge(int left, int right)
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;
                SortArrayOfMerge(left, middle);
                SortArrayOfMerge(middle + 1, right);
                Merge(left, middle, right);
            }
            void Merge(int left, int middle, int right)
            {
                int[] leftTempArray = new int[middle - left + 1];
                int[] rightTempArray = new int[right - middle];

                for (int i = 0; i < middle - left + 1; ++i)
                    leftTempArray[i] = arr[left + i];
                for (int j = 0; j < right - middle; ++j)
                    rightTempArray[j] = arr[middle + 1 + j];
                int q = 0;
                int w = 0;
                int k = left;
                while (q < middle - left + 1 && w < right - middle)
                {
                    if (leftTempArray[q] <= rightTempArray[w])
                    {
                        arr[k++] = leftTempArray[q++];
                    }
                    else
                    {
                        arr[k++] = rightTempArray[w++];
                    }
                }
                while (q < middle - left + 1)
                {
                    arr[k++] = leftTempArray[q++];
                }
                while (w < right - middle)
                {
                    arr[k++] = rightTempArray[w++];
                }
            }
            return arr;
        }


        public void HeapSort()
        {
            int n = arr.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
                heapify(arr, n, i);

            for (int i = n - 1; i >= 0; i--)
            {

                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;


                heapify(arr, i, 0);
            }
            void heapify(int[] arr, int n, int i)
            {
                int largest = i;

                int l = 2 * i + 1;
                int r = 2 * i + 2;


                if (l < n && arr[l] > arr[largest])
                    largest = l;

                if (r < n && arr[r] > arr[largest])
                    largest = r;

                if (largest != i)
                {
                    int swap = arr[i];
                    arr[i] = arr[largest];
                    arr[largest] = swap;

                    heapify(arr, n, largest);
                }
            }
        }
        #endregion

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < arr.Length; i++)
            {
                str += arr[i] + " ";
            }
            return str;
        }
    }
}
