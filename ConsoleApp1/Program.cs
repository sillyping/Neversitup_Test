using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Test 1 Perm : ");
            string val1 = Console.ReadLine();
            foreach (var p in firstSampel(val1))
            {
                Console.Write(" -> " + p);
            }

            Console.WriteLine("Test 2 Odd Number : ");
            string val2 = Console.ReadLine();
            secondSampel(val2);

          
            Console.WriteLine("Test 3 Smiley Face : ");

            int smileyCount = CountSmileyFaces(Console.ReadLine().Split(','));
            Console.WriteLine("Number of smiley faces found: " + smileyCount);
            Console.ReadLine();
        }
        // ------------ Program 1      

        private static IEnumerable<string> firstSampel(string source)
        {
            if (source.Length == 1) return new List<string> { source };

            var permutations = from c in source
                               from p in firstSampel(new String(source.Where(x => x != c).ToArray()))
                               select c + p;

            return permutations;
        }


        ///------------- Program 2 
        private static void secondSampel(string aaa)
        {
            try
            {
                var arrlist = aaa?.Split(',')?.Select(Int32.Parse).ToList();

                List<string> list = new List<string>();
                Dictionary<int, int> countDict = new Dictionary<int, int>();
                foreach (int num in arrlist)
                {
                    if (countDict.ContainsKey(num))
                    {
                        countDict[num]++;
                    }
                    else
                    {
                        countDict[num] = 1;
                    }
                }

                foreach (var entry in countDict)
                {
                    if (entry.Value % 2 != 0)
                    {
                        list.Add(entry.Key.ToString());
                        Console.WriteLine(entry.Key.ToString() + " cuz is occurs : " + entry.Value + " Time");
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("This not int array value");

            }

        }

        //----------------- Program 3
        private static int CountSmileyFaces(string[] faces)
        {
            if (faces.Length == 0) return 0;

            string pattern = "[:;][-~]?[)D]";
            int count = 0;
            foreach (string face in faces)
            {
                MatchCollection matches = Regex.Matches(face, pattern);
                count += matches.Count;
            }
            return count;
        }

    }


}
