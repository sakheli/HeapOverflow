using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WCF.EF
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model11")
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<Replies> Replies { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Posts)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.assignedCategory);

            modelBuilder.Entity<Posts>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<Posts>()
                .Property(e => e.body)
                .IsUnicode(false);

            modelBuilder.Entity<Posts>()
                .HasMany(e => e.Replies)
                .WithMany(e => e.Posts)
                .Map(m => m.ToTable("ReplyDetails").MapLeftKey("postId").MapRightKey("replyId"));

            modelBuilder.Entity<Replies>()
                .Property(e => e.body)
                .IsUnicode(false);

            modelBuilder.Entity<Roles>()
                .Property(e => e.roleName)
                .IsUnicode(false);

            modelBuilder.Entity<Roles>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Roles)
                .HasForeignKey(e => e.roleId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Posts)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.userId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Replies)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.userId)
                .WillCascadeOnDelete(false);
        }
    }
}
