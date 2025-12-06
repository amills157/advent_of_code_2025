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
                foreach (var min_max in range_ids)
                {
                    if (id >= min_max.Item1 && id <= min_max.Item2)
                    {
                        part_one += 1;
                        break;
                    }
                }
            }
             
            Console.WriteLine("part one answer is: {0}", part_one);

        }
        
        // Min and max aren't supported but stop and start are (?)
        public static void partTwo(ref List<(long start, long stop)> ranges)
        {
            var sorted_ranges = ranges.OrderBy(r => r.start).ThenBy(r => r.stop).ToList();
        
            int i = 0;
            // for loop not working here as we are removing elements - So while 
            while (i < sorted_ranges.Count)
            {
                var range1 = sorted_ranges[i];
                int j = i + 1;
        
                while (j < sorted_ranges.Count)
                {
                    var range2 = sorted_ranges[j];
        
                    if (range2.start <= range1.stop)
                    {
                        
                        range1 = (range1.start, Math.Max(range1.stop, range2.stop));
                        sorted_ranges[i] = range1;        
                        sorted_ranges.RemoveAt(j);
                    }
                    else
                    {
                        break;
                    }
                }
        
                i +=1;
            }
        
            long part_two = sorted_ranges.Sum(r => (r.stop - r.start + 1));
        
            Console.WriteLine("part two answer is: {0}", part_two);
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
            
            partTwo(ref range_ids);
        
        }
   }
}