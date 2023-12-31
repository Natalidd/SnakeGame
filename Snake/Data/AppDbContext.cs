﻿using Microsoft.EntityFrameworkCore;
using Snake.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Data
{
    public class AppDbContext : DbContext
    {
        private const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=SnakeGameDb;Trusted_Connection=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<HighScores> HighScores { get; set; }
        public DbSet<GameSaves> GameSaves { get; set; } 

    }
}
