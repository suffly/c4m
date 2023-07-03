using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using c4mApi.Models;

namespace c4mApi.Reprositories
{
    public class C4mDBContext : DbContext
    {
        public DbSet<attach> attach_tbl { get; set; }
        public DbSet<attachres> attachres_tbl { get; set; }
        public DbSet<consulation> consulation_tbl { get; set; }
        public DbSet<consulationdetail> consulationdetail_tbl { get; set; }
        public DbSet<counselor> counselor_tbl { get; set; }
        public DbSet<counselordivision> counselordivision_tbl { get; set; }
        public DbSet<counselortype> counselortype_tbl { get; set; }
        public DbSet<meeting> meeting_tbl { get; set; }
        public DbSet<meetingterm> meetingterm_tbl { get; set; }
        public DbSet<meetingtype> meetingtype_tbl { get; set; }
        public DbSet<ministry> ministry_tbl { get; set; }
        public DbSet<objective> objective_tbl { get; set; }
        public DbSet<partylist> partylist_tbl { get; set; }
        public DbSet<province> province_tbl { get; set; }
        public DbSet<region> region_tbl { get; set; }
        public DbSet<response> response_tbl { get; set; }
        public DbSet<status> status_tbl { get; set; }
        public DbSet<topictype> topictype_tbl { get; set; }
        public DbSet<userlevel> userlevel_tbl { get; set; }
        public DbSet<userprofile> userprofile_tbl { get; set; }



        //public DbContextOptions<C4mDBContext> Options { get; }

        public C4mDBContext(DbContextOptions<C4mDBContext> options) : base(options)
        {
            //Options = options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}
