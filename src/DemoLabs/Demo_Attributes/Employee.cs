using System.ComponentModel.DataAnnotations;

namespace Demo_Attributes
{
    internal class Employee
    {

        private string _firstName = string.Empty;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _firstName = value;
                }
                else
                {
                    throw new ArgumentException(message: "First Name cannot be empty");
                }
            }
        }


        //System.ComponentModel.DataAnnotations.RequiredAttribute
        [Required]
        public int LastName { get; set; }


        [Display(Name = "Department Name")]
        [Required(ErrorMessage = "{0} cannot be empty.")]
        public required string DeptName { get; set; } = string.Empty;

    }

}
