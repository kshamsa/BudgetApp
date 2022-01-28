namespace BudgetApp.Models
{
    public class UserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }   
        public string Password { get; set; }

        public UserModel()
        {
            FirstName = "";
            LastName = "";
            Email = ""; 
            Password = ""; 
        }

        public bool ValidateUser()
        {
            if (FirstName == "")
            {
                return false; 
            }

            if (LastName == "")
            {
                return false; 
            }

            if (Email == "")
            {
                return false; 
            }

            if (Password == "")
            {
                return false; 
            }

            return true;
        }
    }
}
