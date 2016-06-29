namespace LINQ
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class LINQ
    {
        static void Main(string[] args)
        {
            var list = new List<Student>{
                new Student { FirstName = "Ivan", LastName = "Ivanov", Age = 18, GroupNumber = 2, Email = "student@yahoo.com",
                    Tel = "02958645", FN = "0123406", Marks = new List<int> { 2, 3, 4}},
                new Student { FirstName = "Georgi", LastName = "Ivanov", Age = 17, GroupNumber = 1, Email = "student@abv.bg",
                    Tel = "075958645", FN = "0123416", Marks = new List<int> { 2, 3, 4}},
                new Student { FirstName = "Georgi", LastName = "Draganov", Age = 30, GroupNumber = 3, Email = "student@abv.bg",
                    Tel = "02958645", FN = "0123406", Marks = new List<int> { 2, 3, 4}},
                new Student { FirstName = "Ivan", LastName = "Sofiyanski", Age = 24, GroupNumber = 1, Email = "student@gbg.bg",
                    Tel = "05958645", FN = "01223406", Marks = new List<int> { 2, 3, 4}},
                new Student { FirstName = "Petyr", LastName = "Popov", Age = 22, GroupNumber = 3, Email = "student@abv.bg",
                    Tel = "0215958645", FN = "0123409", Marks = new List<int> { 2, 3, 4}},
                new Student { FirstName = "Drago", LastName = "Ivanov", Age = 60, GroupNumber = 2, Email = "student@abv.bg",
                    Tel = "052958645", FN = "0123408", Marks = new List<int> { 2, 3, 4}},
                new Student { FirstName = "Drago", LastName = "Atanasov", Age = 10, GroupNumber = 2, Email = "student@mail.bg",
                    Tel = "0858645", FN = "0123407", Marks = new List<int> { 2, 3, 4}}
            };

            foreach (var student in FilterStudents(list))
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
            Console.WriteLine("-Sorted by Name");
            Console.WriteLine("..............................................................................");

            foreach (var student in FilterStudentsByAge(list))
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
            Console.WriteLine("-Sorted by Age");
            Console.WriteLine("..............................................................................");

            foreach (var student in OrderStudents(list))
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
            Console.WriteLine("-Sorted by Age");
            Console.WriteLine("..............................................................................");

            foreach (var student in GroupNumber(list, 2))
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
            Console.WriteLine("-Extract by GroupNumber");
            Console.WriteLine("..............................................................................");

            foreach (var student in EmailsInABV(list, "abv.bg"))
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
            Console.WriteLine("-Extract by EmailsInABV");
            Console.WriteLine("..............................................................................");

            foreach (var student in TelInSofia(list, "02"))
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
            Console.WriteLine("-Extract by TelInSofia");
            Console.WriteLine("..............................................................................");

            // Problem 13 and 14
            var anonArray = new[] { 
                new { FullName = "Ivan Ivanov", Marks = new List<int> { 2, 4} },
                new { FullName = "Dragan Ivanov", Marks = new List<int> { 3, 4} },
                new { FullName = "Georgi Ivanov", Marks = new List<int> { 6, 4, 5} },
            };

            // Problem 13. Extract students by marks
            var newAnonArr = anonArray
                .Where(x => x.Marks.Contains(6))
                .ToArray();

            foreach (var student in newAnonArr)
            {
                Console.WriteLine(student.FullName);
            }
            Console.WriteLine("-Extract by Excellent");
            Console.WriteLine("..............................................................................");

            // Problem 14. Extract students with two marks
            var newAnonArr1 = anonArray
                .Where(x => x.Marks.Count == 2)
                .ToArray();

            foreach (var student in newAnonArr1)
            {
                Console.WriteLine(student.FullName);
            }
            Console.WriteLine("-Extract by mark count");
            Console.WriteLine("..............................................................................");

            // Problem 15. Extract marks
            var exMarks = list
                .Where(x => x.FN.Substring(5, 2) == "06")
                .Select(x => new {Name = x.FirstName, marks = x.Marks})
                .ToArray();

            foreach (var markList in exMarks)
            {
                Console.Write("{0}`s marks are:", markList.Name);
                foreach (var mark in markList.marks)
                {
                    Console.Write(mark + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-Extract by 2006 year");
            Console.WriteLine("..............................................................................");

            // Problem 17. Longest string
            string[] strArr = new string[] { "a", "abcdef", "abv", "a" };

            var maxLength = strArr
                .OrderBy(x => x.Length)
                .Last();

            Console.WriteLine(maxLength);
            Console.WriteLine("-The longest string");
            Console.WriteLine("..............................................................................");

            // Problem 18. Grouped by GroupNumber

            var groups = list
                .GroupBy(delegate(Student student){
                    return student.GroupNumber;
                })
                .OrderBy(x => x.Key);

            foreach (var group in groups)
            {
                Console.Write("{0} group memnbers are:", group.Key);
                foreach (var member in group)
                {
                    Console.Write(member.FirstName + " " + member.LastName + ";");
                }
                Console.WriteLine();
            }

            Console.WriteLine(maxLength);
            Console.WriteLine("-Grouped by GroupNumber");
            Console.WriteLine("..............................................................................");

        }

        // Problem 3. First before last
        public static List<Student> FilterStudents(List<Student> list)
        {
            var sortedStudents = list
                .Where(x => x.LastName.CompareTo(x.FirstName) > -1)
                .ToList();

            return sortedStudents;
        }

        // Problem 4. Age range
        public static List<Student> FilterStudentsByAge(List<Student> list)
        {
            var sortedStudents = list
                .Where(x => x.Age >= 18 && x.Age <= 24)
                .ToList();

            return sortedStudents;
        }

        // Problem 5. Order students
        public static List<Student> OrderStudents(List<Student> list)
        {
            var orderedStudents = list
                .OrderByDescending(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            return orderedStudents;
        }

        // Problem 9. Student groups
        public static List<Student> GroupNumber(List<Student> list, int groupNumber)
        {
            var orderedStudents = list
                .Where(x => x.GroupNumber == 2)
                .OrderBy(x => x.FirstName)
                .ToList();

            return orderedStudents;
        }

        // Problem 11. Extract students by email
        public static List<Student> EmailsInABV(List<Student> list, string mail)
        {
            var orderedStudents = list
                .Where(x => x.Email.Substring(x.Email.Length - 6, 6) == mail)
                .ToList();

            return orderedStudents;
        }

        // Problem 12. Extract students by phone
        public static List<Student> TelInSofia(List<Student> list, string tel)
        {
            var orderedStudents = list
                .Where(x => x.Tel.Substring(0, 2) == tel)
                .ToList();

            return orderedStudents;
        }

       
    }
}
