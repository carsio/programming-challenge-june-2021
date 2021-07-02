using System;
using Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ImportData
{
    public class Context: ApplicationDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var a = AppDomain.CurrentDomain.BaseDirectory + "../../../../Domain/Capiflix.db";
            optionsBuilder.UseSqlite($"Data Source={a}");
        }
    }
}