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
        
        if (k >= n)
        {
            // Edge case: we have enough "k" to just change everything to a 9
            for (var i = 0; i < n; i++) { number[i] = 9; }
        }
        else
        {
            // Start in the middle and palinize our way out
            int i = (n / 2) - 1;
            int j = i + 1;
            if ((n % 2) == 1) { j += 1; }
            
            while (i >= 0)
            {
                if (number[i] != number[j])
                {
                    if (k == 0)
                    {
                        Console.WriteLine("-1");
                        return;
                    }
                    
                    if (k >= 2 * (i + 1))
                    {
                        // TODO - what if a more significant digit needs to be swapped?
                        k -= 2;
                        number[i] = 9;
                        number[j] = 9;
                    }
                    else
                    {
                        k -= 1;
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
                
                i -= 1; j += 1;
            }
        }
        
        Console.WriteLine(string.Join("", number));
    }
}
