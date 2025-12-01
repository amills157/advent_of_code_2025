using System;
using System.IO;
using System.Collections.Generic;

namespace advent_day_1 {
   class puzzle_1 {

      public static  void partOne(ref List<int> intList, ref List<string> directions)
      {
         // Needs to be an array not a list for .Length
         int[] intArray = intList.ToArray();

         int position = 50;

         int part_one = 0;
         
         for (int i = 0; i < intArray.Length; i++)
         {  

            if (directions[i] == "L")
            {  
               position -= intArray[i];
            }
            else
            {
               position += intArray[i];
            }
            
            position = position % 100;

            if (position == 0)
            {
               part_one += 1;
            }
            
         }

         Console.WriteLine("part one answer is: {0}", part_one);
         
         //Console.WriteLine("part two answer is: {0}", part_one + part_two);
      }
        
         // I am sure there is a smart way to do this - But clearly it has elduded me
         public static void partTwo(ref List<int> intList, ref List<string> directions)
         {
            int position = 50; 
            int part_two = 0; 
            
            int[] intArray = intList.ToArray();
            
            for (int i = 0; i < intArray.Length; i++)
            {
               // So instead we'll just count all the damn positions
               for (int j = 0; j < intArray[i]; j++)
               {
                  if (directions[i] == "L")
                  {
                     position = (position - 1 + 100) % 100;
                  }
                  else
                  {
                     position = (position + 1) % 100; 
                  }
      
                  if (position == 0)
                  {
                     part_two +=1;
                  }

               }
            }
        
            Console.WriteLine("part two answer is: {0}", part_two);
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
         
         partTwo(ref intList, ref directions);

      }
   }
}