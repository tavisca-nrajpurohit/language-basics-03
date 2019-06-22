using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

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

        public static int Selection(int[] protein, int[] carbs, int[] fat, int[] calorie, string diet, List<int> onList){
            if(diet.Length > 0){
                switch (diet[0])
                {
                    case 'C':   onList = findMax(carbs,onList);
                                if(onList.Count>1)
                                    return Selection(protein,carbs,fat,calorie,diet.Substring(1),onList);
                                else
                                    return onList[0];
                    case 'c':   onList = findMin(carbs,onList);
                                if(onList.Count>1)
                                    return Selection(protein,carbs,fat,calorie,diet.Substring(1),onList);
                                else
                                    return onList[0];
                    case 'P':   onList = findMax(protein,onList);
                                if(onList.Count>1)
                                    return Selection(protein,carbs,fat,calorie,diet.Substring(1),onList);
                                else
                                    return onList[0];
                    case 'p':   onList = findMin(protein,onList);
                                if(onList.Count>1)
                                    return Selection(protein,carbs,fat,calorie,diet.Substring(1),onList);
                                else
                                    return onList[0];
                    case 'F':   onList = findMax(fat,onList);
                                if(onList.Count>1)
                                    return Selection(protein,carbs,fat,calorie,diet.Substring(1),onList);
                                else
                                    return onList[0];
                    case 'f':   onList = findMin(fat,onList);
                                if(onList.Count>1)
                                    return Selection(protein,carbs,fat,calorie,diet.Substring(1),onList);
                                else
                                    return onList[0];
                    case 'T':   onList = findMax(calorie,onList);
                                if(onList.Count>1)
                                    return Selection(protein,carbs,fat,calorie,diet.Substring(1),onList);
                                else
                                    return onList[0];
                    case 't':   onList = findMin(calorie,onList);
                                if(onList.Count>1)
                                    return Selection(protein,carbs,fat,calorie,diet.Substring(1),onList);
                                else
                                    return onList[0];
                    default:    return onList[0];
                }
            }else{
                return onList[0];
            }

        }

        public static List<int> findMax(int[] element, List<int> onList){
            int maximum;
            List<int> onListnew = new List<int>();
            if(onList.Count>0){
                maximum=element[onList[0]];
                foreach (int index in onList)
                {
                    if(maximum<element[index])
                        maximum=element[index];
                }
                foreach (int index in onList){
                    if(maximum==element[index])
                        onListnew.Add(index);
                }
            }else{
                maximum = element[0];
                for (int i = 1; i < element.Length; i++)
                {
                    if(maximum<element[i])
                        maximum=element[i];
                }
                for (int i = 0; i < element.Length; i++)
                {
                    if(maximum==element[i])
                        onListnew.Add(i);
                }
            }
            return onListnew;
        }

        public static List<int> findMin(int[] element, List<int> onList){
            int minimum;
            List<int> onListnew = new List<int>();
            if(onList.Count>0){
                minimum=element[onList[0]];
                foreach (int index in onList)
                {
                    if(minimum>element[index])
                        minimum=element[index];
                }
                foreach (int index in onList){
                    if(minimum==element[index])
                        onListnew.Add(index);
                }
            }else{
                minimum = element[0];
                for (int i = 1; i < element.Length; i++)
                {
                    if(minimum>element[i])
                        minimum=element[i];
                }
                for (int i = 0; i < element.Length; i++)
                {
                    if(minimum==element[i])
                        onListnew.Add(i);
                }
            }
            return onListnew;
        }

        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
            // Add your code here.
            int len = protein.Length;
            int[] calorie = new int[len];
            int[] result = new int[dietPlans.Length]; // storing result

            // calculating calorie values for Food Elements
            for (int i = 0; i < len; i++)
            {
                calorie[i] = 9*fat[i] + 5*carbs[i] + 5*protein[i];
            }

            for (int i = 0; i < dietPlans.Length; i++)
            {
                if(dietPlans[i]==""){
                    result[i]= 0;
                }else{
                    result[i] = Selection(protein,carbs,fat,calorie,dietPlans[i],new List<int>());
                }
            }

            return result; // dummy return result

            throw new NotImplementedException();
        }
    }
}
