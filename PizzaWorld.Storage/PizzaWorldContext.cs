using Microsoft.EntityFrameworkCore;
using PizzaWorld.Domain.Models;
using PizzaWorld.Domain.Abstracts;
using System.Collections.Generic;

namespace PizzaWorld.Storage
{
    public class PizzaWorldContext : DbContext
    {   
        // what are we saving
        public DbSet<Store> Store { get; set;}   
        public DbSet<User> Users {get; set;}

        // BIG CHANGE HEERE
        public DbSet<Order> Order {get; set;}

        public DbSet<APizzaModel> Pizzas {get; set;}

     //   public DbSet<AToppingModel> AToppingModels{get;set;}

        public PizzaWorldContext(DbContextOptions<PizzaWorldContext> options) : base(options) { }
        public PizzaWorldContext(){}

        //Make console client work by adding parameterless constructor

        //where is the database
        protected override void OnConfiguring(DbContextOptionsBuilder build)
        {
            build.UseSqlServer("Server=week2taylordb.database.windows.net,1433;Initial Catalog=pizzaboxdb;MultipleActiveResultSets=true;User ID=sqladmin;Password=Password12345");
        }

        // are we normalized
        protected override void OnModelCreating(ModelBuilder build)
        {
            build.Entity<Store>().HasKey(e => e.EntityId);
            build.Entity<User>().HasKey(e => e.EntityId);
            build.Entity<APizzaModel>().HasKey(e => e.EntityId);
            build.Entity<Order>().HasKey(e => e.EntityId);
            build.Entity<AToppingModel>().HasKey(e => e.EntityId);
            build.Entity<ACrustModel>().HasKey(e => e.EntityId);
            
            SeedData(build);

        }
        protected void SeedData(ModelBuilder builder)
        {
            builder.Entity<Store>().HasData(new List<Store>
                {
                    new Store() {EntityId = 2, Name = "One"},
                    new Store() {EntityId = 3 , Name = "Two"},
                    new Store() {EntityId = 4,Name = "Three"},
                    new Store() {EntityId = 5, Name = "Four"},
                    new Store() {EntityId = 6, Name = "Five"},
                    new Store() {EntityId = 7, Name = "Six"}
                }
            );

            builder.Entity<User>().HasData(new List<User>
                {
                    new User() {EntityId = 5, Username = "First"},
                }
            );
        }
    }
}