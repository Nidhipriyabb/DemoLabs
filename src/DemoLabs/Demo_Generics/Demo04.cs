using System.Collections;

namespace Demo_Generics.Demo04
{

    public static class Demo
    {
        public static void RunThis()
        {
            Company objCompany = new Company();

            objCompany.Add(new Employee() { Id = 1, Name = "First Employee" });
            objCompany.Add(new Employee() { Id = 2, Name = "Second Employee" });
            objCompany.Add(new Employee() { Id = 3, Name = "Third Employee" });
            
            objCompany.Add(new Product() { ProductName = "Rice", Price = 20M });
            objCompany.Add(new Product() { ProductName = "Wheat", Price = 30.75M });


            Console.WriteLine("---- extracting all the objects");

            foreach(var obj in objCompany)          // implicitly invokes IEnumerable.GetEnumerator()
            {
                if (obj is Employee)
                {
                    Employee? emp = obj as Employee;
                    if (emp is not null)
                    {
                        Console.WriteLine("EMPLOYEE: ID={0} Name={1}", emp.Id, emp.Name);
                    }
                }
                else if (obj is Product)
                {
                    Product? product = obj as Product;
                    if(product is not null)
                    {
                        Console.WriteLine("PRODUCT: Name={0} Price={1}", product.ProductName, product.Price);
                    }
                }
            }
            Console.WriteLine();


            // To get only employees from the company
            Console.WriteLine("---- extracting all the Employees from the object");
            foreach (Employee emp in (objCompany as IEnumerable<Employee>))
            {
                Console.WriteLine("EMPLOYEE: ID={0} Name={1}", emp.Id, emp.Name);
            }
            Console.WriteLine();

            // To get only products from the company
            Console.WriteLine("---- extracting all the Employees from the object");
            foreach (Product prod in (objCompany as IEnumerable<Product>))
            {
                Console.WriteLine("PRODUCT: Name={0} Price={1}", prod.ProductName, prod.Price);
            }
            Console.WriteLine();

        }

    }



    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }


    public class Product
    {
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }  
    }



    public class Company 
        : IEnumerable, IEnumerable<Product>, IEnumerable<Employee>
    {
        private System.Collections.Generic.List<Employee> theEmployees;
        private System.Collections.Generic.List<Product> theProducts;

        public Company()
        {
            theEmployees = new List<Employee>();
            theProducts = new List<Product>();
        }

        public void Add(Employee emp)
        {
            theEmployees.Add(emp);
        }

        public void Add(Product product)
        {
            theProducts.Add(product);
        }


        #region System.Collections.IEnumerable members (implemented implicitly)

        /// <example>
        ///     foreach( object obj in objCompany ) {...}
        /// </example>  
        public IEnumerator GetEnumerator()
        {
            // Return both collections together
            foreach (var employee in theEmployees)
            {
                yield return employee;
            }

            foreach (var product in theProducts)
            {
                yield return product;
            }
        }

        #endregion


        #region System.Collections.Generic.IEnumerable<Product> members (implemented explicitly)

        /// <example>
        ///     foreach (Product prod in (objCompany as IEnumerable<Product>)) {...}
        /// </example>
        IEnumerator<Product> IEnumerable<Product>.GetEnumerator()
        {
            // foreach(var prod in theProducts)
            // {
            //    yield return prod;
            // }
            return theProducts.GetEnumerator();
        }

        #endregion


        #region System.Collections.Generic.IEnumerable<Employee> members

        /// <example>
        ///     foreach (Employee emp in (objCompany as IEnumerable<Employee>)) {...}
        /// </example>
        IEnumerator<Employee> IEnumerable<Employee>.GetEnumerator()
        {
            return theEmployees.GetEnumerator();
        }
        
        #endregion
    }


}
