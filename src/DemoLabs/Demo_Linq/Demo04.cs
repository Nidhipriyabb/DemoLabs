namespace Demo_Linq.Demo04
{
    internal static class Demo
    {
        internal static void RunThis()
        {
            var employees = new List<Employee>
            {
                new Employee { Name="Amit", Department="IT" },
                new Employee { Name="John", Department="HR" },
                new Employee { Name="Hema", Department="IT" },
                new Employee { Name="Neha", Department="Finance" },
                new Employee { Name="Raj", Department="HR" }
            };

            var query =
                from e in employees
                group e by e.Department into deptGroup
                select deptGroup;

            foreach (var group in query)
            {
                Console.WriteLine($"Department: {group.Key.ToUpper()}");
                foreach (var emp in group)
                {
                    Console.WriteLine($"\t{emp.Name}");
                }
            }
        }
    }

    class Employee
    {
        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
    }

}
