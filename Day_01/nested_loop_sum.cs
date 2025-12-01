using System;
using System.IO;
using System.Collections.Generic;

namespace advent_day_1 {
   class puzzle_1 {

      public static  void partOne(ref List<int> intList, ref List<string> directions){
         // Needs to be an array not a list for .Length
         int[] intArray = intList.ToArray();

         int starting_number = 50;

         int part_one = 0;

         for (int i = 0; i < intArray.Length; i++)
         {  

            if (directions[i] == "L")
            {  
               starting_number = starting_number -= intArray[i];
            }
            else
            {
               starting_number += intArray[i];
            }
            
            starting_number = starting_number % 100;

            if (starting_number == 0)
            {
               part_one += 1;
            }
            
         }

         Console.WriteLine("part one answer is: {0}", part_one);
      }

      static void Main(string[] args) 
      {
         // Load input
         IEnumerable<string> lines = File.ReadLines("example.txt");

         var intList = new List<int>();

         List<string> directions = new List<string>();

         // Convert each string int to int
         foreach (string r in lines)
         {  
            directions.Add(r.Substring(0, 1)); // Gets the first character
            intList.Add(Convert.ToInt32(r.Substring(1)));
         }

         partOne(ref intList, ref directions);

      }
   }
}