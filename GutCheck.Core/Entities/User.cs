﻿namespace GutCheck.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string HashedPassword { get; set; }
        public required string Role { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
