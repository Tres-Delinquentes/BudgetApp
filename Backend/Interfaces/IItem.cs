﻿namespace Backend.Interfaces
{
    public interface IItem
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public float Amount { get; set; }
    }
}
