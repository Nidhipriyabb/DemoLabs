namespace Demo_Linq.Demo06
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
                new Employee { EmployeeName="Amit", DeptId=1, Salary=100M },
                new Employee { EmployeeName="John", DeptId=2, Salary=200M },
                new Employee { EmployeeName="Hema", DeptId=1, Salary=300M },
                new Employee { EmployeeName="Neha", DeptId=3, Salary=400M },
                new Employee { EmployeeName="Raj", DeptId=2, Salary=500M },
            };


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
            Console.WriteLine();

            var report =
                from e in employees
                group e 
                    by e.DeptId             // key 
                    into dept           
                select new
                {
                    DepartmentID = dept.Key,
                    EmployeeCount = dept.Count(),
                    TotalSalary = dept.Sum(x => x.Salary),
                    AvgSalary = dept.Average(x => x.Salary)
                };

            foreach (var item in report)
            {
                Console.WriteLine($"Dept: {item.DepartmentID} Count:{item.EmployeeCount} | Total:{item.TotalSalary} | Avg:{item.AvgSalary}");
            }
            Console.WriteLine();

            var report2 =
                from e in employees
                join d in departments 
                    on e.DeptId equals d.DeptId
                group new { e, d } 
                    by new { d.DeptId, d.DeptName }             // key == new { d.DeptId, d.DeptName }
                    // by d                                     // key == d (department object)
                    into groupDept                              // grouped object
                select new
                {
                    DepartmentID = groupDept.Key.DeptId,
                    DepartmentName = groupDept.Key.DeptName,
                    EmployeeCount = groupDept.Count(),
                    TotalSalary = groupDept.Sum(x => x.e.Salary),
                    AvgSalary = groupDept.Average(x => x.e.Salary)
                };

            foreach (var item in report2)
            {
                Console.WriteLine(
                    $"Dept: {item.DepartmentID} [ {item.DepartmentName} ] | " 
                    + $"Count:{item.EmployeeCount} | Total:{item.TotalSalary} | Avg:{item.AvgSalary}");
            }

        }
    }


    class Employee
    {
        public int DeptId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public decimal Salary { get; set; }
    }

    class Department
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; } = string.Empty;

        public string Company { get; set; } = string.Empty;
    }

}
