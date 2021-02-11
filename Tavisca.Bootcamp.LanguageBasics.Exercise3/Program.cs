using System;
using System.Linq;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Test(
                new[] { 3, 4 }, 
                new[] { 2, 8 }, 
                new[] { 5, 2 }, 
                new[] { "P", "p", "C", "c", "F", "f", "T", "t" }, 
                new[] { 1, 0, 1, 0, 0, 1, 1, 0 });
            Test(
                new[] { 3, 4, 1, 5 }, 
                new[] { 2, 8, 5, 1 }, 
                new[] { 5, 2, 4, 4 }, 
                new[] { "tFc", "tF", "Ftc" }, 
                new[] { 3, 2, 0 });
            Test(
                new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 }, 
                new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 }, 
                new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 }, 
                new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" }, 
                new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 });
            Console.ReadKey(true);
        }

        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {
            var result = SelectMeals(protein, carbs, fat, dietPlans).SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"Fats = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
        }

        public static int[] SelectMeals(int[] protein,int [] carbs,int [] fat,string [] dietPlans)
        {
            // Add your code here.
           // throw new NotImplementedException();
              int[] calorie=new int[protein.Length];
            for(int i=0;i<protein.Length;i++)
            {
                calorie[i]=9*fat[i] + 5*(protein[i]+carbs[i]);

            }
             int[] result = new int[dietPlans.Length];
            for(int i=0;i<dietPlans.Length;i++)
            {
                List<int> common=new List<Int32>();
                char[] diet=dietPlans[i].ToCharArray();
                for (int k=0;k<protein.Length;k++)
                {
                    common.Add(k);

                }
                for(int j=0;j<diet.Length;j++)
                {
                    if(diet[j].Equals('P'))
                    {
                        int max=getValue(protein,common,"max");
                        common=getCommon(protein,common,max);

                    }
                    else if(diet[j].Equals('p'))
                    {
                        int min=getValue(protein,common,"min");
                        common=getCommon(protein,common,min);
                    }
                    else if(diet[j].Equals('C'))
                    {
                        int max=getValue(carbs,common,"max");
                       common=getCommon(carbs,common,max);
                    }
                    else if(diet[j].Equals('c'))
                    {
                        int min=getValue(carbs,common,"min");
                       common=getCommon(carbs,common,min);
                    }
                    else if(diet[j].Equals('F'))
                    {
                        int max=getValue(fat,common,"max");
                       common=getCommon(fat,common,max);
                    }
                    else if(diet[j].Equals('f'))
                    {
                        int min=getValue(fat,common,"min");
                       common=getCommon(fat,common,min);
                    }
                    else if(diet[j].Equals('T'))
                    {
                        int max=getValue(calorie,common,"max");
                        common=getCommon(calorie,common,max);
                    }
                    else if(diet[j].Equals('t'))
                    {
                        for(int b=0;b<common.Count;b++)
                          //  Console.WriteLine("\nt Before getvalue"+common[b]);
                            
                        int min=getValue(calorie,common,"min");
                     //   Console.WriteLine("\nMin"+min);
                        
                        common=getCommon(calorie,common,min);
                        
                        for(int b=0;b<common.Count;b++)
                          //  Console.WriteLine("\nt After getvalue"+common[b]);
                    }
                }
                result[i]=common[0];
            }
                        return result;
        }

        public static int getValue(int[] arr,List<int> common,string op)
        {
            int min=int.MaxValue;
            int max=int.MinValue;
            if (op.Equals("max"))
            {
                for(int i=0;i<common.Count;i++)
                {
                    if (max<arr[common[i]])
                    {
                        max=arr[common[i]];
                    }
                }
                return max;
            }
            else
            {
                for(int i=0;i<common.Count;i++)
                {
                    if(min>arr[common[i]])
                    {
                        min=arr[common[i]];
                    }
                }
                return min;
            }

        }

        public static List<int> getCommon(int[] arr,List<int> common,int val)
        {
            List<int> temp = new List<int>();
            for(int i=0;i<common.Count;i++)
            {
                if (arr[common[i]]==val)
                {
                    temp.Add(common[i]);
                }
            }
            return temp;
        }
    }
}
