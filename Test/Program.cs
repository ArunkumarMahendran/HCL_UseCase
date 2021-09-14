using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            string allParts1 = "eyes,nose,mouth,ears";
            string allParts2 = "eyes,nose,mouth,ears,feet";
            var parts = new string[] {
                        "Bette_feet",
                        "Bette_eyes",
                        "Bette_nose",
                        "Bette_ears",
                        "Bette_mouth",
                        "Colleen_nose",
                        "Astrid_eyes",
                        "Doug_eyes",
                        "Astrid_nose",
                        "Doug_mouth",
                        "Colleen_nose",
                        "Colleen_arms",
                        "Astrid_feet",
                        "Colleen_nose",
                        "Colleen_mouth",
                        "Doug_nose",
                        "Doug_ears",
                        "Astrid_hands",
                        "Doug_eyes"
                        };

            string[] splitAllParts1 = allParts1.Split(",");
            string[] splitAllParts2 = allParts2.Split(",");

            var displayAllPartName1 = GenerateParts(parts, splitAllParts1);
            var displayAllPartsName2 = GenerateParts(parts, splitAllParts2);
            if (displayAllPartName1?.Count > 0)
            {
                Console.WriteLine("The All Part1 matchings are :");
                foreach (string x in displayAllPartName1)                   
                    Console.WriteLine(x);

            }
            if (displayAllPartsName2?.Count > 0)
            {
                Console.WriteLine("The All Part2 matchings are :");
                foreach (string x in displayAllPartsName2)
                    Console.WriteLine(x);
                

            }
            if (displayAllPartName1?.Count == 0 && displayAllPartsName2?.Count == 0)
            {
                Console.WriteLine("No Match Found!!");
            }

        }

        private static List<string> GenerateParts(string[] parts, string[] splitAllParts)
        {
           
            List<string> returnName = new List<string>();
            int matchingValueCount = 0;
            int filteredCount = 0;
            string[] firstName = new string[parts.Count()];            
            string name = string.Empty;

            foreach (string par in parts.OrderBy(x=>x))
            {
                firstName = par.Split("_");
                if (!string.Equals(name, firstName[0]))
                {
                    matchingValueCount = 0;
                    name = firstName[0];
                    var filteredValue = parts.Where(x => x.Contains(name)).Select(x => x).ToList();
                    filteredCount = filteredValue.Count;
                    foreach (string value in filteredValue)
                    {
                        foreach (string partsValue in splitAllParts)
                        {
                            if (string.Equals(partsValue, value.Split("_")[1]))
                                matchingValueCount++;          
                        }                       
                    }
                    if (filteredCount == matchingValueCount)
                    {
                        returnName.Add(firstName[0]);
                    }
                }

            }
            return returnName;
        }
               
            
        }
    }

