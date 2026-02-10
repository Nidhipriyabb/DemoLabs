namespace Demo_Generics.Demo02
{

    class PersonalDetails
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime DOB { get; set; }
    }


    public static class Demo
    {
        public static void RunThis()
        {
            System.Collections.Generic.Dictionary<int, string> dict1
                = new Dictionary<int, string>();

            dict1.Add(1, "First entry");
            dict1.Add(2, "Second entry");
            dict1.Add(3, "Third entry");
            dict1.Add(4, "Fourth entry");

            foreach (var item in dict1)
            {
                Console.WriteLine("{0} {1}", item.Key, item.Value);
            }
            Console.WriteLine();


            System.Collections.Generic.SortedDictionary<int, PersonalDetails> dict2 
                = new SortedDictionary<int, PersonalDetails>();
            PersonalDetails obj1 
                = new PersonalDetails()
                    {
                        Id = 2,
                        Name = "First Employee",
                        DOB = new DateTime(2000, 2, 28)
                    };
            dict2.Add(key: obj1.Id, value: obj1);
            dict2.Add(key: 1, value: new PersonalDetails()
            {
                Id = 1,
                Name = "Second Employee",
                DOB = new DateTime(2000, 10, 12)
            });

            foreach( var item in dict2)
            {
                Console.WriteLine("{0} {1} {2:dd-MMM-yyyy}", item.Key, item.Value.Name, item.Value.DOB);
            }
            Console.WriteLine();

            // dict2[2]
            PersonalDetails obj = dict2[key: 1];   // "Second Employee" because KEY==1
       }

    }

}


