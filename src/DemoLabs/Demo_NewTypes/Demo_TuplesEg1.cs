namespace Demo_NewTypes
{
    internal static class Demo_TuplesEg1
    {
        internal static void RunThis()
        {
            Employee emp1 = new Employee() { Id = 10, Name = "First Employee" };
            emp1.Name = emp1.Name.ToUpper();
            Console.WriteLine("Type={0} : ID={1} Name={2}",
                emp1.GetType(), emp1.Id, emp1.Name);

            // Anoymous Object
            var emp2 = new { Id = 20, Name = "Second employee" };
            // emp2.Name = emp2.Name.ToUpper();
            Console.WriteLine("Type={0} : ID={1} Name={2}",
                emp2.GetType(), emp2.Id, emp2.Name);


            Tuple<int, string> emp3 = new Tuple<int, string>(30, "Third Employee");

            (int, string) emp9 = new (90, "");          // short-hand version of Tuple

            // emp3.Item2 = emp3.Item2.ToUpper();  
            Console.WriteLine("Type={0} : Item1={1} Item2={2}",
                emp3.GetType(), emp3.Item1, emp3.Item2);

            Tuple<int, string, DateTime> emp4
                = new Tuple<int, string, DateTime>(
                    item1: 10,
                    item2: "hello world",
                    item3: new DateTime(2026, 02, 12));

            var arrAnnon = new []
            {
                new { Id = 10, Name = "Hello" },
                new { Id = 20, Name = "world" }
            };

            List<(int, string)> arrTuples = new List<(int, string)>
            {
                 new (1, "hello"),              
                 new (2, "world")
            };

            // C# 12 version of collection initialization
            List<(int, string)> arrTuples2 = [
                 new (1, "hello"),
                 new (2, "world")
            ];
        }

    }

    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
