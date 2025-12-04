using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace advent_day_3 {
   class puzzle_3 {

      public static  void partOne(ref List<string> strings)
      {
        int part_one = 0;
         
         foreach (string r in strings)
         {  
            var intList = new List<int>();
            
            foreach (char c in r )
            {
                intList.Add(Convert.ToInt32(Char.GetNumericValue(c)));
            }
            
            var maxValue = intList.Max();
            
            var maxIdx = intList.IndexOf(intList.Max());
            
            //Console.WriteLine("Max value is {0} at {1}", maxValue, maxIdx);
            
            if (maxIdx == 0)
            {
                var firstDigit = maxValue;
                
                var secondPart = intList.GetRange(maxIdx + 1, intList.Count -1);
                
                var secondDigit = secondPart.Max();
                
                //Console.WriteLine("String is {0}", r);
                
                int highest_joltage = int.Parse(firstDigit.ToString() + secondDigit.ToString());
                
                part_one += highest_joltage;
                
                Console.WriteLine();
            }
            else if (maxIdx == intList.Count -1)
            {
                var secondDigit = maxValue;
                
                var firstPart = intList.GetRange(0, maxIdx);
                
                var firstDigit = firstPart.Max();
                
                int highest_joltage = int.Parse(firstDigit.ToString() + secondDigit.ToString());
                
                part_one += highest_joltage;
                
            }
            else
            {

                var firstDigit = maxValue;
                
                var secondPart = intList.GetRange(maxIdx, intList.Count - maxIdx); 
                secondPart.RemoveAt(0);
                
                var secondDigit = secondPart.Max();
                
                int highest_joltage = int.Parse(firstDigit.ToString() + secondDigit.ToString());
                
                part_one += highest_joltage;
                
            }

         }
         
         Console.WriteLine("part one answer is: {0}", part_one);

        //  partOne(ref intList, ref directions);
         
        //  partTwo(ref intList, ref directions);
      }
        

      static void Main(string[] args) 
      {
        // Load input
        IEnumerable<string> lines = File.ReadLines("example.txt");

         List<string> strings = new List<string>();

         foreach (string r in lines)
         {  
            strings.Add(r);
         }
        
        partOne(ref strings);
        
      }
   }
}