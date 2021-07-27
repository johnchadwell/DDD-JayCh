using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipeClassLibrary.Models;

namespace RecipeAPI1.Models
{
    public class RecipeContext : DbContext
    {
        public RecipeContext(DbContextOptions<RecipeContext> options)
            : base(options)
        {
        }

        //public DbSet<Person> Persons { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<InventoryConditionType> InventoryConditionType { get; set; }
        public DbSet<InventoryUnitType> InventoryUnitType { get; set; }
        public DbSet<IngredientItemType> IngredientItemType { get; set; }
        public DbSet<IngredientItem> IngredientItems { get; set; }
        public DbSet<IngredientUnitType> IngredientUnitType { get; set; }
        public DbSet<IngredientStateType> IngredientStateType { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<FoodItemType> FoodItemType { get; set; }
        public DbSet<TypeClassification> TypeClassification { get; set; }

        ////public DbSet<AlaCarteFoodItem> AlaCarteFoodItems { get; set; }
        ////public DbSet<BeverageFoodItem> BeverageFoodItems { get; set; }
        ////public DbSet<OptionalFoodItem> OptionalFoodItems { get; set; }
        //public DbSet<KindOfMenuItem> KindOfMenuItems { get; set; }
        public DbSet<OptionalMenuItem> OptionalMenuItems { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuCategory> MenuCategories { get; set; }
        public DbSet<Event> Events { get; set; }
        //public DbSet<IGItem> IGItems { get; set; }
        //public DbSet<FItem> FItems { get; set; }
        public DbSet<ProcessedOrders> ProcessedOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Person>().ToTable("Persons");
            modelBuilder.Entity<Customer>().ToTable("Customers");
            //modelBuilder.Entity<Customer>().Property(e => e.Id).ValueGeneratedNever();
            modelBuilder.Entity<Employee>().ToTable("Employees");
            //modelBuilder.Entity<Employee>().Property(e => e.Id).ValueGeneratedNever();
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<OrderItem>()
                .ToTable("OrderItems")
                .HasDiscriminator<string>("OrderItemType")
                .HasValue<AlaCarteOrderItem>("AlaCarte")
                .HasValue<MealOrderItem>("Meal")
                .HasValue<BeverageOrderItem>("Beverage")
                .HasValue<OptionalOrderItem>("Optional");

            modelBuilder.Entity<InventoryItem>().ToTable("InventoryItems");
            modelBuilder.Entity<InventoryItem>().Property(p => p.Yield).HasColumnType("decimal(6,2)");
            modelBuilder.Entity<InventoryItem>().Property(p => p.EqvCup).HasColumnType("decimal(6,2)");
            modelBuilder.Entity<InventoryItem>().Property(p => p.EqvPounds).HasColumnType("decimal(6,2)");
            modelBuilder.Entity<InventoryItem>().Property(p => p.EqvUnits).HasColumnType("decimal(6,2)");
            modelBuilder.Entity<InventoryItem>().Property(p => p.Quantity).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<IngredientItem>().ToTable("IngredientItems");
            modelBuilder.Entity<IngredientItem>().Property(p => p.Amount).HasColumnType("decimal(4,2)");
            modelBuilder.Entity<IngredientItem>().Property(p => p.InventoryUnitCount).HasColumnType("decimal(18,6)");


                //.HasOne(p => p)
                //.WithMany(b => b.PackComponent)
                //.HasForeignKey(p => p.PackId)
                //.WillCascadeOnDelete(false);
                //modelBuilder.Entity<FoodItem>().ToTable("FoodItems");
                //modelBuilder.Entity<FoodItem>()
                //    .ToTable("FoodItems")
                //    .HasDiscriminator<string>("FoodItemType")
                //    .HasValue<AlaCarteFoodItem>("AlaCarte")
                //    .HasValue<BeverageFoodItem>("Beverage")
                //    .HasValue<OptionalFoodItem>("Optional");
            modelBuilder.Entity<FoodItemType>().ToTable("FoodItemType");
            //modelBuilder.Entity<KindOfMenuItem>().ToTable("KindOfMenuItems");
            modelBuilder.Entity<OptionalMenuItem>().ToTable("OptionalMenuItems");
            modelBuilder.Entity<MenuItem>().ToTable("MenuItems");
            modelBuilder.Entity<Menu>().ToTable("Menus");
            modelBuilder.Entity<MenuCategory>().ToTable("MenuCategories");
            modelBuilder.Entity<Event>().ToTable("Events");
            modelBuilder.Entity<ProcessedOrders>().ToTable("ProcessedOrders");
        }

    }
}
