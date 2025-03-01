﻿using GymProject.AppLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymProject.DataAccess
{
    public class GymDbContext: DbContext
    {
        public GymDbContext(DbContextOptions<GymDbContext> options)
            : base(options)
        {
        }
       public DbSet<Booking> Booking { get; set; }
        public DbSet<Classes> Classes { get; set; }
        public DbSet<Corporate> Corporates { get; set; }
        public DbSet<Facilities> Facilities{ get; set; }
        public DbSet<PriceAbonament> PriceAbonament { get; set; }
        public DbSet<Progress> Progress{ get; set; }
        public DbSet<Trainers> Trainers { get; set; }
        


    }
}
