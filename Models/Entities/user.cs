﻿namespace User_Crud.Models.Entities
{
    public class user
    {
        public Guid Id { get; set; }
        public required string  Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string? Phone { get; set; }

    }
}