using System.Collections;

namespace Demo_Generics.Demo03
{

    public static class Demo
    {
        public static void RunThis()
        {
            Company objCompany = new Company();

            objCompany.Add(new Employee() { Id = 2, Name = "Second Employee" });
            objCompany.Add(new Employee() { Id = 1, Name = "First Employee" });

            objCompany.Add(new Product() { ProductName = "Rice", Price = 20M });
            objCompany.Add(new Product() { ProductName = "Wheat", Price = 30.75M });

            objCompany.Add(new Employee() { Id = 3, Name = "Third Employee" });
            

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
        : IEnumerable
    {
        // private System.Collections.ArrayList theEmployees;           // theEmployees.Add(new Product())
        // private System.Collections.ArrayList theProducts;

        // private MyGenericCollection<Employee> theEmployees;
        // private MyGenericCollection<Product> theProducts;

        private System.Collections.Generic.List<Employee> theEmployees;
        private System.Collections.Generic.List<Product> theProducts;

        public Company()
        {
            // theEmployees = new MyGenericCollection<Employee>();
            // theProducts = new MyGenericCollection<Product>();

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

        public IEnumerator GetEnumerator()
        {
            foreach(Employee emp in theEmployees)
            {
                yield return emp; 
            }
            foreach (Product product in theProducts)
            {
                yield return product;
            }
        }

        #endregion

    }


    class MyGenericCollection<T> : IEnumerable
    {
        private System.Collections.ArrayList theItems;

        public MyGenericCollection()
        {
            theItems = new System.Collections.ArrayList();
        }

        public void Add(T item)
        {
            theItems.Add(item);
        }


        #region IEnumerable members

        public IEnumerator GetEnumerator()
        {
            foreach(T item in theItems)
            {
                yield return item; 
            }
        }

        #endregion
    }


}
