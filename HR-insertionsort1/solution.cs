using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void insertionSort(int[] ar) {
        var i = ar.Length - 1;
        var t = ar[i];
        
        while ((i > 0) && (t < ar[i - 1])) {
            ar[i] = ar[i - 1];
            Console.WriteLine(string.Join(" ", ar));
            i -= 1;
        }

        ar[i] = t;
        Console.WriteLine(string.Join(" ", ar));
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

           insertionSort(_ar);
    }
}
