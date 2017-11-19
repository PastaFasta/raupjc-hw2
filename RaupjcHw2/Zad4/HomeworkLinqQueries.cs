using System;
using System.Linq;

namespace Zad4
{
    public class HomeworkLinqQueries
    {
        public static string[] Linq1(int[] intArray)
        {
            return intArray.GroupBy(i => i)
                .OrderBy(i => i.Key)
                .Select(i => $"Broj {i.Key} ponavlja se {i.Count()} puta").ToArray();
        }
        public static University[] Linq2_1(University[] universityArray)
        {
            return universityArray
                .Where(i => i.Students.All(t => t.Gender == Gender.Male)).ToArray();
        }
        public static University[] Linq2_2(University[] universityArray)
        {
            double avrg = universityArray.Average(i => i.Students.Length);
            return universityArray
                .Where(i => i.Students.Length < avrg).ToArray();
        }
        public static Student[] Linq2_3(University[] universityArray)
        {
            return universityArray.SelectMany(i => i.Students).Distinct().ToArray();
        }
        public static Student[] Linq2_4(University[] universityArray)
        {
            return universityArray
                .Where(i => i.Students.All(t => t.Gender == Gender.Male) || i.Students.All(t => t.Gender == Gender.Female))
                .SelectMany(i => i.Students).Distinct().ToArray();
        }
        public static Student[] Linq2_5(University[] universityArray)
        {
            return universityArray
                .SelectMany(i => i.Students)
                .GroupBy(i => i)
                .Where(i => i.Count() > 1)
                .Select(i => i.Key).ToArray();
        }
    }
}
