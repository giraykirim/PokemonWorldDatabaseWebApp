﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pok
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PokemonEntities : DbContext
    {
        public PokemonEntities()
            : base("name=PokemonEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Carries> Carries { get; set; }
        public virtual DbSet<Evolution> Evolution { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Move> Move { get; set; }
        public virtual DbSet<Pokemon> Pokemon { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Trainer> Trainer { get; set; }
        public virtual DbSet<USES> USES { get; set; }
    }
}
