﻿namespace StorageStation.Web.Users.Models
{
    public class RegisterApiModel
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;
        
        public string Username { get; set; }= null!;

        public string Password { get; set; } =  null!;

        public string Email { get; set; } = null!;
        
        public int HouseholdId { get; set; }
    }
}
