﻿namespace GameZone.Models
{
    public class DeleteGameViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Publisher { get; set; } = null!;
    }
}