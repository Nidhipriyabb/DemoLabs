namespace Demo_Attributes.Demo01
{
    internal class Demo
    {
        internal static void RunThis()
        {
            Demo obj = new Demo();

            obj.MyFirstDeprecatedMethod();
            obj.MySecondDeprecatedMethod();
            obj.MyThirdDeprecatedMethod();
            obj.MyFourthDeprecatedMethod();
            // obj.MyFifthDeprecatedMethod();
        }


        /// <summary>
        ///    This is a deprecated method.  
        ///    May be you should use .....
        /// </summary>
        [Obsolete]
        public void MyFirstDeprecatedMethod()
        {
            Console.WriteLine("called MyFirstdeprecatedMethod().");
        }

        /// <summary>
        ///    Another way of indicating a deprecated method
        /// </summary>
        [ObsoleteAttribute]
        public void MySecondDeprecatedMethod()
        {
            Console.WriteLine("called MySecondDeprecatedMethod().");
        }

        /// <summary>
        ///    You can also provide your own comment
        /// </summary>
        [Obsolete(message: "You shouldn't use this method anymore.")]
        public void MyThirdDeprecatedMethod()
        {
            Console.WriteLine("called MyThirdDeprecatedMethod().");
        }

        [Obsolete(message: "You cannot use this method", error: false)]
        public void MyFourthDeprecatedMethod()
        {
            Console.WriteLine("called MyFourthDeprecatedMethod().");
        }

        [Obsolete("You cannot use this method", error: true)]
        public void MyFifthDeprecatedMethod()
        {
            Console.WriteLine("called MyFifthDeprecatedMethod().");
        }

    }
}
