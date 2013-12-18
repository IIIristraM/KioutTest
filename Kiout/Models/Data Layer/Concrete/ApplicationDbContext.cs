using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Kiout.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Сourse> Сourses { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Organization> Organizations { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Сourse>().HasKey(u => u.Id);
            modelBuilder.Entity<Group>().HasKey(a => a.Id);
            modelBuilder.Entity<Instructor>().HasKey(s => s.Id);
            modelBuilder.Entity<Employee>().HasKey(p => p.Id);
            modelBuilder.Entity<Organization>().HasKey(m => m.Id);

            modelBuilder.Entity<Employee>()
                        .HasMany(e => e.Groups)
                        .WithMany(g => g.Emoployees)
                        .Map(t => t.MapLeftKey("EmoployeeId")
                                   .MapRightKey("GroupId")
                                   .ToTable("GroupEmoployee"));

            modelBuilder.Entity<Group>()
                        .HasRequired(g => g.Сourse)
                        .WithMany(c => c.Groups)
                        .HasForeignKey(g => g.CourseId)
                        .WillCascadeOnDelete(true);

            modelBuilder.Entity<Group>()
                        .HasRequired(g => g.Instructor)
                        .WithMany(i => i.Groups)
                        .HasForeignKey(g => g.InstructorId)
                        .WillCascadeOnDelete(true);

            modelBuilder.Entity<Employee>()
                        .HasRequired(e => e.Organization)
                        .WithMany(o => o.Emoployees)
                        .HasForeignKey(e => e.OrganizationId)
                        .WillCascadeOnDelete(true);

            modelBuilder.Entity<Organization>()
                        .HasOptional(o => o.Instrictor)
                        .WithMany(i => i.Organizations)
                        .HasForeignKey(o => o.InstructorId)
                        .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}