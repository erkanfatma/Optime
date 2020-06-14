namespace AU.Optime.Entities.Concrete {
      using System.Data.Entity;
      /// <summary>
      /// OptimeContext is the primary class that is responsible for interacting with the database.
      /// </summary>
      public partial class OptimeContext : DbContext {
            public OptimeContext()
                : base("name=OptimeContext") {

                  //this.Configuration.LazyLoadingEnabled = false;
                  //this.Configuration.ProxyCreationEnabled = false;
            }

            // The entity set of type DbSet<TEntity> for all the entities. 
            public virtual DbSet<Board> Boards { get; set; }
            public virtual DbSet<Documentation> Documentations { get; set; }
            public virtual DbSet<Note> Notes { get; set; }
            public virtual DbSet<Project> Projects { get; set; }
            public virtual DbSet<ProjectToUser> ProjectToUsers { get; set; }
            public virtual DbSet<SubTask> SubTasks { get; set; }
            public virtual DbSet<TaskDetail> TaskDetails { get; set; }
            public virtual DbSet<Task> Tasks { get; set; }
            public virtual DbSet<UserDetail> UserDetails { get; set; }
            public virtual DbSet<User> Users { get; set; }


            //OnModelCreating method is used to configure model using DbBuilder Fluent API in the project
            protected override void OnModelCreating(DbModelBuilder modelBuilder) {
                  modelBuilder.Entity<Board>()
                      .Property(e => e.Name)
                      .IsUnicode(false);

                  modelBuilder.Entity<Documentation>()
                      .Property(e => e.DocumentationURL)
                      .IsUnicode(false);

                  modelBuilder.Entity<Note>()
                      .Property(e => e.Description)
                      .IsUnicode(false);

                  modelBuilder.Entity<Project>()
                      .Property(e => e.Name)
                      .IsUnicode(false);

                  modelBuilder.Entity<Project>()
                      .Property(e => e.Description)
                      .IsUnicode(false);

                  modelBuilder.Entity<Project>()
                      .HasMany(e => e.Documentations)
                      .WithOptional(e => e.Project)
                      .HasForeignKey(e => e.RelationId);

                  modelBuilder.Entity<Project>()
                      .HasMany(e => e.ProjectToUsers)
                      .WithRequired(e => e.Project)
                      .WillCascadeOnDelete(false);

                  modelBuilder.Entity<Task>()
                      .Property(e => e.Title)
                      .IsUnicode(false);

                  modelBuilder.Entity<Task>()
                      .Property(e => e.Description)
                      .IsUnicode(false);

                  modelBuilder.Entity<Task>()
                      .HasMany(e => e.Documentations)
                      .WithOptional(e => e.Task)
                      .HasForeignKey(e => e.RelationId);

                  modelBuilder.Entity<Task>()
                      .HasOptional(e => e.TaskDetail)
                      .WithRequired(e => e.Task);

                  modelBuilder.Entity<Task>()
                      .HasMany(e => e.Users)
                      .WithMany(e => e.Tasks1)
                      .Map(m => m.ToTable("TaskToUsers").MapLeftKey("TaskId").MapRightKey("UserId"));

                  modelBuilder.Entity<UserDetail>()
                      .Property(e => e.ImageURL)
                      .IsUnicode(false);

                  modelBuilder.Entity<User>()
                      .Property(e => e.Email)
                      .IsUnicode(false);

                  modelBuilder.Entity<User>()
                      .Property(e => e.Password)
                      .IsUnicode(false);

                  modelBuilder.Entity<User>()
                      .Property(e => e.Username)
                      .IsUnicode(false);

                  modelBuilder.Entity<User>()
                      .Property(e => e.FullName)
                      .IsUnicode(false);

                  modelBuilder.Entity<User>()
                      .HasMany(e => e.ProjectToUsers)
                      .WithRequired(e => e.User)
                      .WillCascadeOnDelete(false);

                  modelBuilder.Entity<User>()
                      .HasMany(e => e.Tasks)
                      .WithOptional(e => e.User)
                      .HasForeignKey(e => e.UserId);

                  modelBuilder.Entity<User>()
                      .HasOptional(e => e.UserDetail)
                      .WithRequired(e => e.User);
            }
      }
}
