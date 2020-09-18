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
        public virtual DbSet<PersonModel> Persons { get; set; }
        public virtual DbSet<SpaceshipModel> Spaceships { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PersonModel>().ToTable("Persons");
            builder.Entity<PersonModel>().HasKey(p => p.ID);
            builder.Entity<PersonModel>().HasData(new
            {
                ID = (long)1,
                Name = "sebastian"
            }, new
            {
                ID = (long)2,
                Name = "Eric"
            }); ;


            builder.Entity<PersonModel>().ToTable("Persons");
            builder.Entity<PersonModel>().HasKey(p => p.ID);
            builder.Entity<PersonModel>().HasData(new
            {
                ID = (long)1,
                Name = "sebastian"
            }, new
            {
                ID = (long)2,
                Name = "Eric"
            }); ;
        }
    }
}
