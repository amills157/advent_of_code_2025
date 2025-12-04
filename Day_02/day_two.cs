using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace advent_day_2 {
   class puzzle_2 {

      public static  void partOne(ref Dictionary<long, long> ranges_dict)
      {
        long part_one = 0;
        
        foreach (var kvp in ranges_dict)
        {
            //Console.WriteLine("Key: {0}, Value: {1}", kvp.Key, kvp.Value);
            for (long i = kvp.Key; i <= kvp.Value; i++)
            {
                string string_i = i.ToString();
                
                if (string_i.Length % 2 == 0)
                {
                    var firstHalf = string_i.Substring(0, string_i.Length / 2);
                    string secondHalf = string_i.Substring(string_i.Length / 2);
                    
                    if (firstHalf == secondHalf)
                    {
                        //Console.WriteLine(i);
                        part_one += i;
                    }
                }
                
            }
            
            //Console.WriteLine("-----------------");
        }
        
        Console.WriteLine("part one answer is: {0}", part_one);

        //  partOne(ref intList, ref directions);
         
        //  partTwo(ref intList, ref directions);
      }
        

      static void Main(string[] args) 
      {
        // Load input
        string contents = File.ReadAllText("example.txt");

        string[] ranges_list = contents.Split(',');
        
        Dictionary<long, long> ranges_dict = new Dictionary<long, long>();
         
        for (int i = 0; i < ranges_list.Length; i++)
        {
            long[] ids = ranges_list[i].Split('-').Select(long.Parse).ToArray();
            
            ranges_dict.Add(ids[0], ids[1]); // Adds the key-value pair   

        }
        
        partOne(ref ranges_dict);
        
      }
   }
}