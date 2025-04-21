﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hotdesk.Components.Models;
using Hotdesk.Models;

namespace Hotdesk.Data
{
    public class HotdeskContext : DbContext
    {
        public HotdeskContext (DbContextOptions<HotdeskContext> options)
            : base(options)
        {
        }

        public DbSet<Hotdesk.Components.Models.Desk> Desk { get; set; } = default!;
        public DbSet<Hotdesk.Models.Booking> Booking { get; set; } = default!;
    }
}
