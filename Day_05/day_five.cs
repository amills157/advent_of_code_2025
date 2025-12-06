using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace advent_day_5 {
   class puzzle_5 {

      public static  void partOne(ref List<(long, long)> range_ids, ref List<long> ids)
      {
        long part_one = 0;
        
        foreach (long id in ids)
        {
            //Console.WriteLine(id);
            foreach (var min_max in range_ids)
            {
                if (id >= min_max.Item1 && id <= min_max.Item2)
                {
                    part_one += 1;
                    //Console.WriteLine("Fresh");
                    break;
                }
            }
        }
         
        Console.WriteLine("part one answer is: {0}", part_one);

      }
        

      static void Main(string[] args) 
      {
        
        // Load input
        IEnumerable<string> lines = File.ReadLines("example.txt");
        
        bool input_split = false;
        
        var range_ids = new List<(long, long)>();
        
        var ids = new List<long>();
    
        foreach (string r in lines)
        {  
            if (string.IsNullOrEmpty(r))
            {
                input_split = true;
            }
            
            if (!input_split)
            {
                long[] id_min_max = r.Split('-').Select(long.Parse).ToArray();
                    
                range_ids.Add((id_min_max[0], id_min_max[1])); // Adds the key-value pair   
        
            }
            else
            {
                if (!string.IsNullOrEmpty(r))
                {   
                    ids.Add(long.Parse(r));
                }
            }
        }
        
        partOne(ref range_ids, ref ids);
        
      }
   }
}