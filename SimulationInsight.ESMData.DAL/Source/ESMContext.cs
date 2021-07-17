using Microsoft.EntityFrameworkCore;
using SimulationInsight.ESMData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationInsight.ESMData.DAL
{
    public class ESMContext : DbContext
    {
        public string ConnectionString { get; set; }

        public DbSet<Mission> Missions { get; set; }
        public DbSet<Recording> Recordings { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<PulseDescriptor> PulseDescriptors { get; set; }

        public ESMContext() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            ConnectionString = "Server=localhost;Database=ESM;Trusted_Connection=True;";

            options.UseSqlServer(ConnectionString);
        }
    }
}
