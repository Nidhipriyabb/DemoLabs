namespace Demo_Attributes
{

    // 1. All Attribute Classes should have the suffix "Attribute" in the name
    // 2. It has to inherit from System.Attribute
    // 3. Apply the AttributeUsage guidelines/policy
    // [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]

    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class DeveloperAttribute : System.Attribute
    {
        // Private fields.
        private readonly string name;
        private readonly string level;
        private bool reviewed;

        // This constructor defines two required parameters: name and level.
        public DeveloperAttribute(string name, string level)
        {
            this.name = name;
            this.level = level;
            this.reviewed = false;
        }


        // Define Name property.
        // This is a read-only attribute.
        public virtual string Name
        {
            get { return name; }
        }


        // Define Level property.
        // This is a read-only attribute.
        public virtual string Level
        {
            get { return level; }
        }


        // Define Reviewed property. 
        // This is a read/write attribute. 
        public virtual bool Reviewed
        {
            get { return reviewed; }
            set { reviewed = value; }
        }
    }

}
