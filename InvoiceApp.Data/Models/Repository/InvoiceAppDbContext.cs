﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApp.Data.Models.Repository
{
    public class InvoiceAppDbContext : IdentityDbContext<ApplicationUser>
    {
        public InvoiceAppDbContext(DbContextOptions<InvoiceAppDbContext> options) : base(options) 
        {

        }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<InvoiceIdTracker> InvoiceIdTrackers { get; set; }
        public DbSet<ProfilePicture> ProfilePictures { get; set; }
        public DbSet<SwaggerCredential> SwaggerCredentials { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<RecurringInvoice> RecurringInvoices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Invoices) 
                .WithOne(i => i.User) 
                .HasForeignKey(i => i.UserID) 
                .IsRequired(); 

            modelBuilder.Entity<Invoice>()
                .HasKey(i => i.Id); 

            modelBuilder.Entity<Invoice>()
                .HasMany(i => i.Items) 
                .WithOne(it => it.Invoice) 
                .HasForeignKey(it => it.InvoiceID)
                .OnDelete(DeleteBehavior.Cascade);  

            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.SenderAddress) 
                .WithMany() 
                .HasForeignKey(i => i.SenderAddressID) 
                .IsRequired() 
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.ClientAddress) 
                .WithMany() 
                .HasForeignKey(i => i.ClientAddressID) 
                .IsRequired() 
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Item>()
                .HasKey(it => it.Id); 

            modelBuilder.Entity<Address>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<SwaggerCredential>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<RecurringInvoice>()
                .HasKey(ri => ri.Id);

            modelBuilder.Entity<RecurringInvoice>()
                .HasOne(ri => ri.Invoice)
                .WithMany()
                .HasForeignKey(ri => ri.InvoiceId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RecurringInvoice>()
                .HasIndex(ri => new { ri.InvoiceId, ri.RecurrenceDate })
                .IsUnique();
        }
    }
}
