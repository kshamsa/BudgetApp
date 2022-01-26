﻿namespace BudgetApp.Models
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

    }
}
