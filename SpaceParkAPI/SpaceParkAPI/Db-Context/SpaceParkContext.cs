﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SpaceParkAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkAPI.Db_Context
{
    public class SpaceParkContext : DbContext
    {
        public SpaceParkContext() { }
        private IConfiguration _configuration;

        public SpaceParkContext(IConfiguration config, DbContextOptions<SpaceParkContext> options) : base(options)
        {
            this._configuration = config;
        }

        public virtual DbSet<ParkingLotModel> ParkingLots { get; set; }
        public virtual DbSet<ParkingSpaceModel> ParkingSpaces { get; set; }
        public virtual DbSet<PersonModel> PersonModels { get; set; }
        public virtual DbSet<SpaceshipModel> SpaceshipModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}