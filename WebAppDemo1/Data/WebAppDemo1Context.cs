﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppDemo1.Models;

namespace WebAppDemo1.Data
{
    public class WebAppDemo1Context : DbContext
    {
        public WebAppDemo1Context (DbContextOptions<WebAppDemo1Context> options)
            : base(options)
        {
            Database.EnsureCreated();

        }

        public DbSet<WebAppDemo1.Models.CloudEngineer> CloudEngineer { get; set; }
    }
}
