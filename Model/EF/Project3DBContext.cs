namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Model.ViewModel;
 

    public partial class Project3DBContext : DbContext
    {
        public Project3DBContext()
            : base("name=eProject3")
        {
        }

        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }

        public virtual DbSet<Question> Questions { get; set; }
        
        public virtual DbSet<User> Users { get; set; }
        
        public virtual DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
  
  
            modelBuilder.Entity<User>()
                .Property(e => e.Role)
                .IsUnicode(false);

  
            modelBuilder.Entity<Contact>().Property(e => e.ID).IsOptional();
                

        }

        
    }
}
