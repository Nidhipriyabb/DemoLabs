namespace Demo_Attributes.Demo02
{
    internal static class Demo
    {
        internal static void RunThis()
        {
            Console.WriteLine("ATTRIBUTES OF ClassA:");
            ShowAttributeInfo(typeof(ClassA));
            Console.WriteLine();

            Console.WriteLine("ATTRIBUTES OF ClassB:");
            ShowAttributeInfo(typeof(ClassB));
            Console.WriteLine();

            Console.WriteLine("ATTRIBUTES OF ClassC:");
            ShowAttributeInfo(typeof(ClassC));
            Console.WriteLine();

            Console.WriteLine("ATTRIBUTES OF ClassC extracted from the Object:");
            ClassC objC = new ClassC();
            ShowAttributeInfo(objC.GetType());
            Console.WriteLine();

            ShowAllDeveloperAttributes(typeof(ClassC));
        }


        private static void ShowAllDeveloperAttributes(System.Type tClassType)
        {
            var attributes
                = (DeveloperAttribute[]?)Attribute.GetCustomAttributes(
                        tClassType, typeof(DeveloperAttribute));
            if (attributes is not null)
            {
                foreach (var attr in attributes)
                {
                    // Get the Name value   
                    Console.WriteLine("The Name Attribute is: {0}.", attr.Name);

                    // Get the Level value 
                    Console.WriteLine("The Level Attribute is: {0}.", attr.Level);

                    // Get the Reviewed value
                    Console.WriteLine("The Reviewed Attribute is: {0}.", attr.Reviewed);
                    attr.Reviewed = false;    // setting the value
                    Console.WriteLine("The Reviewed Attribute is: {0}.", attr.Reviewed);
                }
            }
        }

        private static void ShowAttributeInfo(System.Type tClassType)
        {
            // Get instance of the attribute  
            DeveloperAttribute? myAttribute
                = (DeveloperAttribute?)Attribute.GetCustomAttribute(
                                            tClassType, typeof(DeveloperAttribute));

            if (myAttribute is null)
            {
                Console.WriteLine("No Developer attributes were found.");
            }
            else
            {
                // Get the Name value   
                Console.WriteLine("The Name Attribute is: {0}.", myAttribute.Name);

                // Get the Level value 
                Console.WriteLine("The Level Attribute is: {0}.", myAttribute.Level);

                // Get the Reviewed value
                Console.WriteLine("The Reviewed Attribute is: {0}.", myAttribute.Reviewed);
                myAttribute.Reviewed = false;    // setting the value
                Console.WriteLine("The Reviewed Attribute is: {0}.", myAttribute.Reviewed);
            }
        }
    }


    [Developer("Manoj Kumar Sharma", "80")]
    public class ClassA
    {
    }


    [Developer(name:"Manoj", level:"34", Reviewed = true)]
    class ClassB
    {
        // DeveloperAttribute obj
        //      = new DeveloperAttribute(name: "Abc", level: "22", Reviewed = true);    // COMPILER ERROR
        // DeveloperAttribute obj
        //      = new DeveloperAttribute(name: "Abc", level: "22") { Reviewed = true }; // Object Initializer
    }


    class ClassC
    {
    }
}
