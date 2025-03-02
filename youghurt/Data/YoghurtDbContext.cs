using Microsoft.EntityFrameworkCore;
using youghurt.Models;

namespace youghurt.Data;

public class YoghurtDbContext : DbContext
{

    public YoghurtDbContext(DbContextOptions<YoghurtDbContext> options ) 
        : base(options){
    }
        
    public DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.ToTable("vehicles");
            entity.HasKey(v => v.Id);
            entity.Property(v => v.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            
            entity.Property(v => v.RegistrationNumber)
                .HasColumnName("registration_number")
                .HasMaxLength(12)
                .IsRequired();

            entity.Property(v => v.Type)
                .HasColumnName("type");
                
                
            entity.Property(v => v.CarMake)
                .HasColumnName("car_make")
                .HasMaxLength(12)
                .IsRequired();
                
            entity.Property(v => v.CarModel)
                .HasColumnName("car_model")
                .HasMaxLength(12);

            entity.Property(v => v.ModelDate)
                .HasColumnName("model_date")
                .IsRequired();
            
            entity.Property(v => v.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("getdate()");
            
            entity.Property(v => v.CarMake)
                .HasColumnName("car_make")
                .IsRequired()
                .HasMaxLength(12);

          

        });
    }
}