namespace Demo_Attributes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Demo01.Demo.RunThis();
            
            Demo02.Demo.RunThis();

            // Employee emp = new Employee();      // COMPILER ERROR (validated by "required" keyword for Prop
            Employee emp = new Employee() { DeptName = string.Empty };      
        }
    }
}
