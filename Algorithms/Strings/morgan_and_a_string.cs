using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
         int dataLine = int.Parse(Console.ReadLine());
         for(int cases = 0; cases < dataLine; cases++){
             String first = Console.ReadLine();
             String second = Console.ReadLine();
             String concat = first + 'a' + second + 'b';
             
             String[] suffix = new String[concat.Length];
             
             int concatLength = concat.Length;

             for(int count = 0; count < concatLength; count++){
                 suffix[count] = concat;
                 concat = concat.Substring(1);
             }
             
             int[] lexicPos = new int[concatLength];
             for(int index = 0; index < concatLength; index++){
                 lexicPos[index] = index;
             }
             
             for (int a = 1; a < concatLength; a++){
                for (int b = concatLength - 1; b >= a; b--)
                {
                    var compare = Solution.compareString(suffix[lexicPos[b -1]], suffix[lexicPos[b]]);
                    if (compare > 0)
                    {
                        var t = lexicPos[b - 1];
                        lexicPos[b - 1] = lexicPos[b];
                        lexicPos[b] = t;
                    }
                }
             }
          
             String res = "";
             int pos1=0, pos2=0;
             
             int aLenght = first.Length;
             int bLenght = second.Length;
             
             while (true)
                {
                    if (pos1 >= (aLenght) && pos2 >= (bLenght))
                    {
                        break;
                    }
                    if (pos1 >= (aLenght-1))
                    {
                        res += second[pos2++];
                        continue;
                    }
                    if (pos2 >= (bLenght-1))
                    {
                        res += first[pos1++];
                        continue;
                    }
                    if (lexicPos[pos1] < lexicPos[aLenght + pos2])
                        res += first[pos1++];
                    else
                        res += second[pos2++];
                }
             Console.WriteLine(res);
         }
    }
    
    static int compareString(String string1, String string2){
        var count = 0;
        var ascii1 = (int)string1[count];
        var ascii2 = (int)string2[count];
        while(ascii1 == ascii2 && count < string1.Length && count < string2.Length){
            count++;
            ascii1 = (int)string1[count];
            ascii2 = (int)string2[count];
        }
        if(ascii1 == ascii2){
            return (string1.Length).CompareTo(string2.Length);
        }
        return ascii1.CompareTo(ascii2);
    }
}