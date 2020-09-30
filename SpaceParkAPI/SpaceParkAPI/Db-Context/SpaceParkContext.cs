using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SpaceParkAPI.Models;
using SpaceParkAPI.Services;
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
        AzureKeyVaultService _aKVService = new AzureKeyVaultService();

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
            var azureDbCon = _aKVService.GetKeyVaultSecret("https://spaceparkkv.vault.azure.net/secrets/dbcon/177aa99fc9a64986b14bb47e92d82012");
            if(string.IsNullOrEmpty(azureDbCon))
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));               
            }
            else
            {
                optionsBuilder.UseSqlServer(azureDbCon);
            }
        }

        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PersonModel>().ToTable("Persons");
            builder.Entity<PersonModel>().HasKey(p => p.ID);
            builder.Entity<PersonModel>().HasOne(p => p.Spaceship).WithOne(s => s.Person);
            builder.Entity<PersonModel>().HasData(new
            {
                ID = (long)1,
                Name = "sebastian",
                SpaceshipID = (long)1
            }, new
            {
                ID = (long)2,
                Name = "Eric",
                SpaceshipID = (long)2
            }); ;

            builder.Entity<SpaceshipModel>().HasKey(s => s.ID);
            builder.Entity<SpaceshipModel>().HasOne(s => s.ParkingSpace).WithOne(p => p.Spaceship);
            builder.Entity<SpaceshipModel>().ToTable("Spaceships");
            builder.Entity<SpaceshipModel>().HasData(new
            {
                ID = (long)1,
                ParkingSpaceID = (long)1
            }, new
            {
                ID = (long)2,
                ParkingSpaceID = (long)2
            }); ;

            builder.Entity<ParkingSpaceModel>().ToTable("ParkingSpaces");
            builder.Entity<ParkingSpaceModel>().HasKey(p => p.ID);
            builder.Entity<ParkingSpaceModel>().HasOne(ps => ps.Spaceship).WithOne(s => s.ParkingSpace);
            builder.Entity<ParkingSpaceModel>().HasData(new
            {
                ID = (long)1,
                ParkingLotID = (long)1
            }, new
            {
                ID = (long)2,
                ParkingLotID = (long)1
            }); ;

            builder.Entity<ParkingLotModel>().ToTable("ParkingLots");
            builder.Entity<ParkingLotModel>().HasKey(p => p.ID);
            builder.Entity<ParkingLotModel>().HasMany(pl => pl.ParkingSpaces).WithOne(ps => ps.ParkingLot);
            builder.Entity<ParkingLotModel>().HasData(new
            {
                ID = (long)1,
                TotalAmount = (long)15,
                
            }, new
            {
                ID = (long)2,
                TotalAmount = (long)14,
              
            }); ;            

            
        }
    }
}
