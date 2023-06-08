using GestionRH.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;


namespace GestionRH.Context
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration)
    : base(options)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SqlConnection");
        }
        #region Constructor

        #endregion

        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<Credit>()
                .Property(d => d.Status)
                .HasConversion(new EnumToStringConverter<Status>());
            modelBuilder
            .Entity<Conge>()
                .Property(d => d.Status)
                .HasConversion(new EnumToStringConverter<Status>());
            modelBuilder
            .Entity<Autorisation>()
                .Property(d => d.Status)
                .HasConversion(new EnumToStringConverter<Status>());
        }

        #region Déclaration DbSet
        public virtual DbSet<Credit> Credit { get; set; }
        public virtual DbSet<Conge> Conge { get; set; }
        public virtual DbSet<Autorisation> Autorisation { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Employe> Employees { get; set; }
        #endregion

    }
}
