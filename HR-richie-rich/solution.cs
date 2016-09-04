using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int k = Convert.ToInt32(tokens_n[1]);
        
        var number = Console.ReadLine().ToCharArray().Select(x => int.Parse(x.ToString())).ToArray();

        // Count the number of required swaps
        int required = 0;
        for (int i = 0, j = n - 1; i < n / 2; i++, j--)
        {
            if (number[i] != number[j])
            {
                required += 1;
            }
        }
        
        // Determine how many "extra" swaps we have left over
        int extra = k - required;
        
        // Console.WriteLine(extra);
        
        // If we can't make a palindrome, we're done.
        if (extra < 0)
        {
            Console.WriteLine(-1);
            return;
        }

        // Go through and make the swaps, taking advantage of extras...
        for (int i = 0, j = n - 1; i < n / 2; i++, j--)
        {
            if (extra >= 2)
            {
                if (number[i] != 9)
                {
                    number[i] = 9;
                    extra -= 1;
                }
                if (number[j] != 9)
                {
                    number[j] = 9;
                    extra -= 1;
                }
            }
            else if (extra >= 1 && number[j] > number[i])
            {
                number[i] = number[j];
                extra -= 1;
            }
            else if (number[i] != number[j])
            {
                if (number[i] > number[j])
                {
                    number[j] = number[i];
                }
                else
                {
                    number[i] = number[j];
                }
            }
        }
        
        // Print the result
        Console.WriteLine(string.Join("", number));
    }
}
