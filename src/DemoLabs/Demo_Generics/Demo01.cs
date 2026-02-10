namespace Demo_Generics.Demo01
{

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public override string ToString()
        {
            return string.Format("{0} : {1}", this.Id, this.Name);
        }
    }

    public class MyGenericClass<T>
    {
        private T? _value;

        public T? Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine("My Generic Type developed at Trivium for {0}", this.GetType());
            Console.WriteLine("Value: {0}", this.Value);            // this.Value.ToString()
        }
    }

    public static class Demo
    {
        public static void RunThis()
        {
            int i = 10;
            object o = i;
            Employee e = new Employee();

            MyGenericClass<int> objInt = new MyGenericClass<int>();
            objInt.Value = 10;
            objInt.ShowInfo();
            Console.WriteLine();

            MyGenericClass<string> objString = new MyGenericClass<string>();
            objString.Value = "hello world";
            objString.ShowInfo();
            Console.WriteLine();

            MyGenericClass<Employee> objEmployee = new MyGenericClass<Employee>();
            objEmployee.Value = new Employee();
            objEmployee.Value.Id = 10;
            objEmployee.Value.Name = "First Employee";
            objEmployee.ShowInfo();
            Console.WriteLine();
        }
    }
}
