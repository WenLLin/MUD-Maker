using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mud_Maker.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Mud> Muds { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Fight> Fights { get; set; }
        public DbSet<Health> HealthBar { get; set; }
        public DbSet<Item> Items { get; set; }
    }
    public class Mud
    {
        public int MudId { get; set; }
        public string MudName { get; set; }
        public string MudDescription { get; set; }
    }
    public class Event
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public string EventText { get; set; }
        public bool EventTriggered { get; set; }
        public int? DirLeft { get; set; }
        public int? DirRight { get; set; }
        public int? DirFwd { get; set; }
        public int? DirBack { get; set; }
        public int FightId { get; set; }
        public Fight Fight { get; set; }
        public int HealthId { get; set; }
        public Health Health { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }

        public int MudId { get; set; }
        public Mud Mud { get; set; }
    }

    public class Fight
    {
        public int FightId { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }
        public string Name { get; set; }
    }

    public class Health
    {
        public int HealthId { get; set; }
        public bool IsGained { get; set; }
        public int Amount { get; set; }
    }

    public class Item
    {
        public int ItemId { get; set; }
        public bool IsGained { get; set; }
        public string Object { get; set; }
    }

}
