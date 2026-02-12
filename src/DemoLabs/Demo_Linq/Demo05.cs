namespace Demo_Linq.Demo05
{
    internal static class Demo
    {
        internal static void RunThis()
        {
            var departments = new List<Department>
            {
                new Department { DeptId=1, DeptName="IT" },
                new Department { DeptId=2, DeptName="HR" },
                new Department { DeptId=3, DeptName="Finance" }
            };

            var employees = new List<Employee>
            {
                new Employee { EmployeeName="Amit", DeptId=1 },
                new Employee { EmployeeName="John", DeptId=2 },
                new Employee { EmployeeName="Hema", DeptId=1 },
                new Employee { EmployeeName="Neha", DeptId=3 },
                new Employee { EmployeeName="Raj", DeptId=2 }
            };

            /********************
                SELECT e.EmployeeName, d.DeptName
                FROM Employees e
                JOIN Departments d ON e.DeptId = d.DeptId
            **********/

            var query =
                from e in employees
                join d in departments on e.DeptId equals d.DeptId
                select new
                {
                    EmployeeName = e.EmployeeName,
                    DepartmentName = d.DeptName
                };

            foreach (var item in query)
            {
                Console.WriteLine($"{item.EmployeeName} WORKS IN {item.DepartmentName}");
            }
        }
    }

    class Employee
    {
        public int DeptId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
    }

    class Department
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; } = string.Empty;
    }

}
