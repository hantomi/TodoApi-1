﻿namespace TodoApi
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Password { get; set; } = null;

        public string Phone { get; set; }

        public string Email { get; set; } = string.Empty;

        public string Address { get; set; }

        public int TripId { get; set; }
    }
}
