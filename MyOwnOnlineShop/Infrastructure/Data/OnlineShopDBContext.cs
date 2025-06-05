﻿using Application.Services;
using Domain.Common;
using Domain.Entities;
using FluentEmail.Core.Models;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using static Domain.Entities.Order;

namespace Infrastructure.Data;
public class OnlineShopDBContext : IdentityDbContext<ApplicationUser>
{
    private readonly UserResolverService _userResolverService;

    public OnlineShopDBContext(DbContextOptions<OnlineShopDBContext> options, UserResolverService userService)
        : base(options)
    {
        _userResolverService = userService;
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Picture> Pictures { get; set; }
    public DbSet<Domain.Entities.Attachment> Attachments { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<PersonalInfo> PersonalInfos { get; set; }

    public async Task<int> SaveChangesAsync()
    {
        var entries = ChangeTracker
               .Entries()
               .Where(e => e.Entity is AuditableEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            ((AuditableEntity)entityEntry.Entity).LastModified = DateTime.UtcNow;
            ((AuditableEntity)entityEntry.Entity).LastModifiedBy = _userResolverService.GetUser();

            if (entityEntry.State == EntityState.Added)
            {
                ((AuditableEntity)entityEntry.Entity).Created = DateTime.UtcNow;
                ((AuditableEntity)entityEntry.Entity).CreatedBy = _userResolverService.GetUser();
            }
        }
        return await base.SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}