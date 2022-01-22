namespace BudgetApp.Models
{
    public class UserModel
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public UserModel()
        {
            Name = "";
            Password = ""; 
        }

    }
}
