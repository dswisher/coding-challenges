
using System;
using System.Collections.Generic;

class Solution {

// Partition the array between the left and right points
static int Partition(int[] ar, int left, int right) {
    var p = ar[left];  // pivot
    // TODO - partition in place!
    var leftList = new List<int>();
    var rightList = new List<int>();
    for (var i = left; i <= right; i++) {
        if (ar[i] < p) {
            leftList.Add(ar[i]);
        } else if (ar[i] < p) {
            rightList.Add(ar[i]);
        }   
    }
    
    var j = left;
    foreach (var x in leftList) {
        ar[j++] = x;
    }
    ar[j++] = p;
    foreach (var x in rightList) {
        ar[j++] = x;
    }
    
    Console.WriteLine("{0} {1} {2}", string.Join(" ", leftList), p, string.Join(" ", rightList));
    
    return left + leftList.Count;
}

static void QuickSort(int[] ar, int left, int right) {
    var mid = Partition(ar, left, right);
    
    Console.WriteLine("mid={0}", mid);
    // TODO - sort the sub-partitions!
}
    
static void QuickSort(int[] ar) {
    QuickSort(ar, 0, ar.Length - 1);
}

/* Tail starts here */
    static void Main(String[] args) {
           
           int _ar_size;
           _ar_size = Convert.ToInt32(Console.ReadLine());
           int [] _ar =new int [_ar_size];
           String elements = Console.ReadLine();
           String[] split_elements = elements.Split(' ');
           for(int _ar_i=0; _ar_i < _ar_size; _ar_i++) {
                  _ar[_ar_i] = Convert.ToInt32(split_elements[_ar_i]); 
           }

           QuickSort(_ar);
    }
}
