using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        var n = Convert.ToInt32(Console.ReadLine());
        var B = Console.ReadLine().ToCharArray();
        var num = 0;
        for (var i = 2; i < n; i++) {
            if (B[i] == '0' && B[i-1] == '1' && B[i-2] == '0') {
                B[i] = '1';
                num += 1;
            }
        }
        Console.WriteLine(num);
    }
}
