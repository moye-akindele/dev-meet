﻿using DevMeetData.Models;
using Microsoft.EntityFrameworkCore;

namespace DevMeetData.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Seat> Seats { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventBooking> EventBookings { get; set; }
        public DbSet<BookingItem> BookingItems { get; set; }
    }
}
